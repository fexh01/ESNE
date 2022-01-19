using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaBoton : MonoBehaviour
{
    public Color defaultColour; //Color en reposo
    public Color selectedColour; //Color cuando se selecciona un boton
    private Material mat;


    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }
    void OnTouchDown()
    {
        mat.color = selectedColour;
    }
    void OnTouchUp()
    {
        mat.color = defaultColour;
    }
    void OnTouchStay()
    {
        mat.color = selectedColour;
    }
    void OnTouchExit()
    {
        mat.color = defaultColour;
    }
}
