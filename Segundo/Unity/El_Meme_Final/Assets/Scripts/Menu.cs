using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject nombresPantalla;
    public GameObject rondasPantalla;
    Controlador controlador;
    public int nombresIntroducidos;

    private void Start()
    {
        controlador = GameObject.Find("Controlador").GetComponent<Controlador>();
        nombresIntroducidos = 0;
    }

    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GetNumJugadores()
    {
        InputField input = GameObject.Find("InputNumJugadores").GetComponent<InputField>();
        Text error = GameObject.Find("ErrorNumJugadores").GetComponent<Text>();

        if (input.text != "4" && input.text != "5" && input.text != "6")
        {
            error.text = "Valor no válido (4-6)";
        }
        else
        {
            int.TryParse(input.text, out controlador.numJugadores);
            error.text = " ";
            GameObject.Find("NumJugadores").SetActive(false);
            nombresPantalla.SetActive(true);
            controlador.jugadores = new Jugador[controlador.numJugadores];
        }
    }

    public void GetNombre()
    {
        
        InputField input = GameObject.Find("InputNombres").GetComponent<InputField>();
        Text error = GameObject.Find("ErrorNombres").GetComponent<Text>();
        Text texto = GameObject.Find("TextoNombres").GetComponent<Text>();

        if (nombresIntroducidos < controlador.numJugadores - 1)
        {
            if(input.text == " " || input.text == "  " || input.text == "   ")
            {
                error.text = "Introduce un nombre";
            }
            else
            {
                controlador.CrearJugador(nombresIntroducidos, input.text);
                ++nombresIntroducidos;
                error.text = null;
                input.text = " ";
            }

            texto.text = ("Introduce el nombre del jugador " + (nombresIntroducidos + 1).ToString());
        }
        else
        {
            if (input.text == " " || input.text == "  " || input.text == "   ")
            {
                error.text = "Introduce un nombre";
            }
            else
            {
                controlador.CrearJugador(nombresIntroducidos, input.text);
                ++nombresIntroducidos;
                error.text = " ";
                input.text = " ";
            }

            ++nombresIntroducidos;
            nombresPantalla.SetActive(false);
            rondasPantalla.SetActive(true);
        }

    }

    public void GetNumRondas()
    {
        InputField input = GameObject.Find("InputRondas").GetComponent<InputField>();
        Text error = GameObject.Find("ErrorRondas").GetComponent<Text>();

        if (input.text != "3" && input.text != "4" && input.text != "5" && input.text != "6" && input.text != "7" && input.text != "8" && input.text != "9" && input.text != "10")
        {
            error.text = "Valor no válido (3-10)";
        }
        else
        {
            int.TryParse(input.text, out controlador.rondas);
            error.text = " ";
            Jugar();
        }
    }

}
