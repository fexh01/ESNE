using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meme : MonoBehaviour
{
    public Controlador controlador;
    public Juego juego;
    public Image imagen;
    
    private void Awake()
    {
        controlador = GameObject.Find("Controlador").GetComponent<Controlador>();
        juego = GameObject.Find("Canvas").GetComponent<Juego>();
        imagen = GetComponent<Image>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void seleccionarMeme()
    {
        juego.memesCandidatos[juego.numMemesElegidos] = imagen.sprite;
        controlador.jugadores[juego.turnoJugador - 1].spriteSeleccionado = imagen.sprite;
    }

    public void SeleccionarFinalista()
    {
        //Debug.Log("Finalista Seleccionado" + this.gameObject.name);

        for (int i = 0; i < controlador.jugadores.Length; i++)
        {
            if (controlador.jugadores[i].spriteSeleccionado == imagen.sprite)
            {
                juego.ganadorRonda = controlador.jugadores[i];
            }
        }

        juego.juezEligePantalla.SetActive(false);
        juego.ganadorRondaPantalla.SetActive(true);

        Text textoGanadorRonda = GameObject.Find("NombreGanadorRonda").GetComponent<Text>();

        textoGanadorRonda.text = juego.ganadorRonda.nombre + "!";
        ++juego.ganadorRonda.partidasGanadas;
    }
}
