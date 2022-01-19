using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    public Button boton;
    public Volumen controlador;
    void Start()
    {
        boton = GetComponent<Button>();
        controlador = GameObject.Find("ControladorVolumen").GetComponent<Volumen>();

        if(controlador.muted == true)
        {
            boton.image.sprite = controlador.mute;
        }
        else
        {
            boton.image.sprite = controlador.unmute;
        }
    }
    public void Mute()
    {
        boton.image.sprite = controlador.mute;
        AudioListener.volume = 0;
        controlador.muted = true;
    }

    public void Unmute()
    {
        boton.image.sprite = controlador.unmute;
        AudioListener.volume = 1;
        controlador.muted = false;
    }

    public void click()
    {
        if(controlador.muted == true)
        {
            Unmute();
        }
        else
        {
            Mute();
        }
    }

    void Update()
    {
        
    }
}
