using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortero : MonoBehaviour
{
    public GameObject CannonBala;
    public float RadioDeDaño;
    public int Daño = 100;
    public float DisparosPorSegundo;
    public float rango = 2;
    float TiempoParaElDisparo;
    public float VelocidadY = 4;
    public float Gravedad = 4f;
    public int municionMaxima = 10;
    public int municion;
    GameObject Base;
    int precioDeMunMaxima = 10;
    GameObject Dinero;
    private void Awake()
    {
        Base = GameObject.FindGameObjectsWithTag("Base")[0];
        TiempoParaElDisparo = 1 / DisparosPorSegundo;
        municion = municionMaxima;
        Dinero = GameObject.FindGameObjectWithTag("Dinero");
    }
    void Update()
    {
        if (municion > 0)
        {
            TiempoParaElDisparo -= Time.deltaTime;
            if (TiempoParaElDisparo <= 0)
            {
                TiempoParaElDisparo = 1 / DisparosPorSegundo;
                if (ConseguirEnemigoCercano() != null)
                {
                    GameObject Enemigo = ConseguirEnemigoCercano();
                    GameObject Temporal = Instantiate(CannonBala);
                    Temporal.transform.position = transform.position;
                    Molotov ScriptTemporal = Temporal.GetComponent<Molotov>();
                    ScriptTemporal.velocidad = VelocidadY;
                    ScriptTemporal.Gravedad = Gravedad;
                    ScriptTemporal.RadioDeDanio = RadioDeDaño;
                    ScriptTemporal.Damage = Daño;
                    Temporal.GetComponent<Rigidbody2D>().velocity = Enemigo.transform.position - transform.position;
                    --municion;
                }
            }
        }
    }
    GameObject ConseguirEnemigoCercano()
    {
        Vector2 Direccion = new Vector2(0, 0);
        GameObject[] Enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
        GameObject EnemigoCercano = Enemigos[0];
        bool EnemigoEncontrado = false;
        if (Enemigos.Length > 0)
        {
            EnemigoCercano = Enemigos[0];
            for (int i = 0; i < Enemigos.Length; ++i)
            {
                if (Vector2.Distance(transform.position, Enemigos[i].transform.position) < rango)
                {
                    if (EnemigoEncontrado)
                    {
                        if (Vector2.Distance(Base.transform.position, EnemigoCercano.transform.position) > Vector2.Distance(Base.transform.position, Enemigos[i].transform.position))
                        {
                            EnemigoCercano = Enemigos[i];
                        }
                    }
                    else
                    {
                        EnemigoCercano = Enemigos[i];
                    }
                    EnemigoEncontrado = true;
                }
            }
        }
        if (!EnemigoEncontrado)
        {
            EnemigoCercano = null;
        }
        return EnemigoCercano;
    }
    void OnTouchDown()
    {
        if (municion == 0)
        {
            municion = municionMaxima;
            Dinero.GetComponent<Dinero>().QuitaDinero(precioDeMunMaxima);
        }
    }
}