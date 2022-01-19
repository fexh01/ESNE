using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public string nombre;
    public int partidasGanadas;
    public Sprite spriteSeleccionado;

    void Start()
    {
        partidasGanadas = 0;
    }
}
