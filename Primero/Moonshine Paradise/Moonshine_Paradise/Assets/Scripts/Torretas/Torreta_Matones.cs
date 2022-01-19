using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

public class Torreta_Matones : MonoBehaviour
{
    public float rango = 2.5f;
    [Range(0, 100)]
    public float PorcentajeSlow;
    public int DamagePorSegunda;
    GameObject Base;
    public GameObject Maton;
    bool matonesSpawneados = false;
    public AudioSource Placa;

    private void Start()
    {
        Base = GameObject.FindGameObjectWithTag("Base");
        if (gameObject.name == "Torreta_matonesFuncionamiento(Clone)")
        {
            //Esto es jodidamente cutre pero estoy hasta loscojones deesto
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (!matonesSpawneados)
        {
            if (ConseguirEnemigoCercano() != null)
            {
                GetComponent<Animator>().SetBool("EnemigosEnRango", true);
                if (ConseguirEnemigoCercano().transform.position.x - transform.position.x > 0)
                {
                    for (int i = 0; i <= 1; ++i)
                    {
                        GameObject Clon = Instantiate(Maton);
                        Clon.transform.position = transform.position + Vector3.right * i * 0.2f;
                        Clon.GetComponent<Maton>().vaHaciaDerecha = true;
                        Clon.GetComponent<Maton>().PorcentajeSlow = PorcentajeSlow;
                        Clon.GetComponent<Maton>().dañoPorSegundo = DamagePorSegunda;
                    }
                }
                else
                {
                    for (int i = 0; i <= 1; ++i)
                    {
                        GameObject Clon = Instantiate(Maton);
                        Clon.transform.position = transform.position + Vector3.right * i * 0.2f;
                        Clon.GetComponent<Maton>().vaHaciaDerecha = false;
                        Clon.GetComponent<Maton>().PorcentajeSlow = PorcentajeSlow;
                        Clon.GetComponent<Maton>().dañoPorSegundo = DamagePorSegunda;
                    }
                }
                matonesSpawneados = true;

            }
        }
    }
    GameObject ConseguirEnemigoCercano()
    {
        Vector2 Direccion = new Vector2(0, 0);
        GameObject[] Enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
        GameObject EnemigoCercano = null;
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
}