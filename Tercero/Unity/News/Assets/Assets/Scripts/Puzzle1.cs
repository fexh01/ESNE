using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1 : MonoBehaviour
{
    public Puzzle1TV TV3;
    public Puzzle1TV TV4;
    public Puzzle1TV TV5;

    public Receptor interruptor3;
    public Receptor interruptor4;
    public Receptor interruptor5;

    public puerta puerta;

    public bool terminado;

    public GameObject muro1;
    public GameObject muro2;

    // Start is called before the first frame update
    void Start()
    {
        terminado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (interruptor3.active)
        {
            if (TV3.encendida)
            {
                TV3.encendida = false;
            }
            else
            {
                TV3.encendida = true;
            }

            if (TV4.encendida)
            {
                TV4.encendida = false;
            }
            else
            {
                TV4.encendida = true;
            }
        }
        if (interruptor4.active)
        {
            if (muro1.activeSelf)
            {
                muro1.SetActive(false);

            }

            if (TV3.encendida)
            {
                TV3.encendida = false;
            }
            else
            {
                TV3.encendida = true;
            }

            if (TV5.encendida)
            {
                TV5.encendida = false;
            }
            else
            {
                TV5.encendida = true;
            }

        }
        if (interruptor5.active)
        {
            if (muro2.activeSelf)
            {
                muro2.SetActive(false);
            }

            if (TV4.encendida)
            {
                TV4.encendida = false;
            }
            else
            {
                TV4.encendida = true;
            }
        }









        if (!TV3.encendida && !TV4.encendida && !TV5.encendida)
        {
            terminado = true;
        }
        if (terminado && puerta.closed)
        {
            puerta.canBeUsed = false;
            puerta.closed = false;
            puerta.audioSource.clip = puerta.openDoorSound;
            puerta.audioSource.Play();
        }
    }
}
