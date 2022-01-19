using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlador : MonoBehaviour
{
    public int numJugadores;
    public Jugador[] jugadores;
    public int rondas;
    public int ronda;
    public Jugador juez;

    public Sprite[] frases = new Sprite[45];
    public GameObject fraseObject;
    Image imageFrase;

    public Sprite[] memes = new Sprite[45];


    private void Start()
    {
        DontDestroyOnLoad(this);
        ronda = 0;

        //Debug.Log(juez.partidasGanadas);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //FraseAleatoria();
        }
    }

    public void FraseAleatoria()
    {
        int numAleatorio;
        numAleatorio = Random.Range(0, frases.Length);

        imageFrase = fraseObject.GetComponent<Image>();
        imageFrase.sprite = frases[numAleatorio];
    }

    public void CrearJugador(int nombresIntroducidos, string name)
    {
        jugadores[nombresIntroducidos] = gameObject.AddComponent<Jugador>();
        jugadores[nombresIntroducidos].nombre = name;
    }
    
    public void EleccionJuez()
    {
        int numAleatorio;

        numAleatorio = Random.Range(0, numJugadores);
        juez = jugadores[numAleatorio];
    }
}
