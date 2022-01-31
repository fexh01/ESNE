using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public bool activo;
    public GameObject luz;
    public float tiempo;
    public float tiempoActual;
    public float intervalo;
    public float intervaloActual;

    // Start is called before the first frame update
    void Start()
    {
        activo = false;
        intervaloActual = intervalo;
        tiempoActual = tiempo;
    }

    // Update is called once per frame
    void Update()
    {
        if (activo)
        {
            if(tiempoActual > 0)
            {
                tiempoActual = tiempoActual - Time.deltaTime;
                if(intervaloActual > 0)
                {
                    intervaloActual = intervaloActual - Time.deltaTime;
                }
                else
                {
                    if (luz.activeSelf)
                    {
                        luz.SetActive(false);
                    }
                    else
                    {
                        luz.SetActive(true);
                    }
                    intervaloActual = intervalo;
                }

            }
            else
            {
                activo = false;
                tiempoActual = tiempo;
            }

        }
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            activo = true;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            //activo = false;
        }
    }
}
