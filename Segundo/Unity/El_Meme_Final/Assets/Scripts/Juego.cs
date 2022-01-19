using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Juego : MonoBehaviour
{
    public Controlador controlador;
    public GameObject frasePantalla;
    public GameObject jugadorEligePantalla;
    public GameObject juezEligePantalla;
    public int numMemesElegidos;
    public int numsAleatoriosElegidos;
    int numAleatorio;
    public GameObject[] memesAleatorios;
    public Image[] opcionesJuez;
    public Button[] botonesOpcionesJuez;
    public int[] numsAleatorios;
    public Text textoJuez;
    public Text textoNombreJugador;
    public Sprite[] memesCandidatos;
    public int turnoJugador;
    public Sprite transparente;
    public Jugador ganadorRonda;
    public GameObject ganadorRondaPantalla;
    public GameObject ganadorPartidaPantalla;
    public Jugador ganadorJuego;

    void Start()
    {
        numMemesElegidos = 0;
        turnoJugador = 0;
        controlador = GameObject.Find("Controlador").GetComponent<Controlador>();
        numsAleatorios = new int[(4 * (controlador.numJugadores - 1))];
        controlador.EleccionJuez();
        //Debug.Log(controlador.juez.nombre);
        memesAleatorios = new GameObject[4];
        opcionesJuez = new Image[5];
        botonesOpcionesJuez = new Button[5];
        memesCandidatos = new Sprite[controlador.numJugadores-1];
        textoJuez = GameObject.Find("TextoJuez").GetComponent<Text>();
        textoJuez.text = "El juez es " + controlador.juez.nombre;

        for (int i = 0; i < numsAleatorios.Length; i++)
        {
            numsAleatorios[i] = -1;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //controlador.FraseAleatoria();
        }
    }

    public void MostrarFrase()
    {
        frasePantalla.SetActive(true);

        controlador.fraseObject = GameObject.Find("Frase");

        controlador.FraseAleatoria();
    }

    public void EmpezarElecciónMemes()
    {
        frasePantalla.SetActive(false);
        jugadorEligePantalla.SetActive(true);

        textoNombreJugador = GameObject.Find("TextoNombreJugador").GetComponent<Text>();

        if (controlador.juez == controlador.jugadores[0])
        {
            turnoJugador = 1;
            textoNombreJugador.text = controlador.jugadores[1].nombre;
            ++turnoJugador;
        }
        else
        {
            textoNombreJugador.text = controlador.jugadores[0].nombre;
            ++turnoJugador;
        }
        
        memesAleatorios[0] = GameObject.Find("Meme1");
        memesAleatorios[1] = GameObject.Find("Meme2");
        memesAleatorios[2] = GameObject.Find("Meme3");
        memesAleatorios[3] = GameObject.Find("Meme4"); 

        for (int i = 0; i < memesAleatorios.Length; ++i)
        {

            bool memeDecidido = false;

            while (!memeDecidido)
            {
                numAleatorio = Random.Range(0, controlador.memes.Length);
                memeDecidido = true;

                if (numsAleatorios[0] != -1)
                {
                    int j = 0;
                    while (numsAleatorios[j] != -1)
                    {
                        if (numAleatorio == numsAleatorios[j])
                        {
                            memeDecidido = false;
                        }
                        ++j;
                    }
                }
            }

            numsAleatorios[numsAleatoriosElegidos] = numAleatorio;
            ++numsAleatoriosElegidos;
            //Debug.Log("El meme " + i + "tiene el sprite " + numAleatorio);
            Image sprite = memesAleatorios[i].GetComponent<Image>();
            sprite.sprite = controlador.memes[numAleatorio];
        }
    }

    public void JugadorElige()
    {
        if (numMemesElegidos < controlador.numJugadores - 2)
        {
            ++numMemesElegidos;

            if(controlador.juez != controlador.jugadores[controlador.jugadores.Length - 1])
            {
                if (controlador.jugadores[turnoJugador] == controlador.juez)
                {
                    ++turnoJugador;
                }
            }
            textoNombreJugador.text = controlador.jugadores[turnoJugador].nombre;
            ++turnoJugador;

            for (int i = 0; i < memesAleatorios.Length; ++i)
            {

                bool memeDecidido = false;

                while (!memeDecidido)
                {
                    numAleatorio = Random.Range(0, controlador.memes.Length);
                    memeDecidido = true;

                    if (numsAleatorios[0] != -1)
                    {
                        int j = 0;
                        while (numsAleatorios[j] != -1)
                        {
                            if (numAleatorio == numsAleatorios[j])
                            {
                                memeDecidido = false;
                            }
                            ++j;
                        }
                    }
                }

                numsAleatorios[numsAleatoriosElegidos] = numAleatorio;
                ++numsAleatoriosElegidos;
                //Debug.Log("El meme " + i + "tiene el sprite " + numAleatorio);
                Image sprite = memesAleatorios[i].GetComponent<Image>();
                sprite.sprite = controlador.memes[numAleatorio];
            }
        }
        else
        {
            ++numMemesElegidos;
            jugadorEligePantalla.SetActive(false);
            juezEligePantalla.SetActive(true);
            Text nombreJuez = GameObject.Find("NombreJuez").GetComponent<Text>();
            nombreJuez.text = "Juez " + controlador.juez.nombre;

            opcionesJuez[0] = GameObject.Find("Opcion1").GetComponent<Image>();
            opcionesJuez[1] = GameObject.Find("Opcion2").GetComponent<Image>();
            opcionesJuez[2] = GameObject.Find("Opcion3").GetComponent<Image>();
            opcionesJuez[3] = GameObject.Find("Opcion4").GetComponent<Image>();
            opcionesJuez[4] = GameObject.Find("Opcion5").GetComponent<Image>();

            botonesOpcionesJuez[0] = GameObject.Find("Opcion1").GetComponent<Button>();
            botonesOpcionesJuez[1] = GameObject.Find("Opcion2").GetComponent<Button>();
            botonesOpcionesJuez[2] = GameObject.Find("Opcion3").GetComponent<Button>();
            botonesOpcionesJuez[3] = GameObject.Find("Opcion4").GetComponent<Button>();
            botonesOpcionesJuez[4] = GameObject.Find("Opcion5").GetComponent<Button>();

            int i;
            for ( i = 0; i < controlador.numJugadores - 1; i++)
            {
                opcionesJuez[i].sprite = memesCandidatos[i];
            }
            while(i < 5)
            {
                opcionesJuez[i].sprite = transparente;
                botonesOpcionesJuez[i].interactable = false;
                ++i;
            }
        }
    }

    public void RondaTerminada()
    {
        if(controlador.ronda < controlador.rondas - 1)
        {
            ++controlador.ronda;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            ganadorRondaPantalla.SetActive(false);
            ganadorPartidaPantalla.SetActive(true);

            ganadorJuego = controlador.jugadores[0];
            for (int i = 0; i < controlador.numJugadores; i++)
            {
                if (controlador.jugadores[i].partidasGanadas > ganadorJuego.partidasGanadas)
                {
                    ganadorJuego = controlador.jugadores[i];
                }
            }

            Text textoGanadorPartida = GameObject.Find("NombreGanadorJuego").GetComponent<Text>();
            textoGanadorPartida.text = ganadorJuego.nombre + "!";
        }
    }

    public void JuegoTerminado()
    {
        Destroy(controlador.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
