using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;
public class Maton : MonoBehaviour
{
    public float vida = 100;
    public float PorcentajeSlow;
    public int dañoPorSegundo;
    float tiempoParaElDisparo;
    public bool vaHaciaDerecha;
    float PosYInicial;
    // Start is called before the first frame update
    void Start()
    {
        PosYInicial = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < PosYInicial + 0.36f)
        {
            transform.position = new Vector3(transform.position.x - 0.0006f, transform.position.y + 0.001f, transform.position.z);
        }
        else
        {
            VerificarGiro();
            if (vaHaciaDerecha)
            {
                GetComponent<Animator>().SetBool("PegaEspalda", true);
                GetComponent<Animator>().SetBool("PegaFrente", false);
            }
            else
            {
                GetComponent<Animator>().SetBool("PegaFrente", true);
                GetComponent<Animator>().SetBool("PegaEspalda", false);
            }
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemigo")
        {
            collision.gameObject.GetComponent<Enemigo>().HacerDaño(dañoPorSegundo * Time.deltaTime);
            vida -= 3 * Time.deltaTime;
            if (vida <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<PathFollower>().speed -= collision.gameObject.GetComponent<PathFollower>().speed * PorcentajeSlow / 100;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<PathFollower>().resetSpeed();
    }
    void VerificarGiro()
    {
        if (transform.position.x - ConseguirEnemigoCercano().transform.position.x> 0)
        {
            vaHaciaDerecha = false;
        }
        else
        {
            vaHaciaDerecha = true;
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
                if (EnemigoEncontrado)
                {
                    if(Vector2.Distance(transform.position, Enemigos[i].transform.position)< Vector2.Distance(transform.position, EnemigoCercano.transform.position))
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
        if (!EnemigoEncontrado)
        {
            EnemigoCercano = null;
        }
        return EnemigoCercano;
    }
}
