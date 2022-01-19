using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemigo : Zombie
{
    public int dineroExtra;
    public float vida = 100;
    public float daño;
    public float intervaloAtaque;
    private float contadorIntervaloAtaque;
    bool SaliendoDelEditor = false;
    private bool haMuerto = false;
    private GameObject controlador;
    void Start()
    {
        ControlarAnimaciones();
        contadorIntervaloAtaque = intervaloAtaque;
    }
    private void Update()
    {
        ControlarAnimaciones();
    }
    void OnApplicationQuit()
    {
        SaliendoDelEditor=true;
    }
    private void OnDestroy()
    {
        if (!SaliendoDelEditor && haMuerto)
        {
            controlador.GetComponent<Controlador>().ZombieMuerto(dineroExtra);
        }
    }
    public void HacerDaño(int daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            haMuerto = true;
            Destroy(gameObject);
        }
    }
    public void HacerDaño(float daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Base")
        {
            contadorIntervaloAtaque -= Time.deltaTime;
            if (contadorIntervaloAtaque <= 0)
            {
                collision.gameObject.GetComponent<Vida>().vidaBar -= daño;
                contadorIntervaloAtaque = intervaloAtaque;
            }

        }

    }

    public void setControlador(GameObject controller)
    {
        controlador = controller;
    }


}

