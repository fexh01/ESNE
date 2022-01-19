using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{

    public GameObject Bala;
    int LayerEnemigos;
    public float DisparosPorSegundo;
    float TiempoParaElDisparo;
    public int Damage = 20;
    public int municionMaxima = 100;
    public int municion;
    public float rango;
    public GameObject SpriteTorreta;
    int precioDeMunMaxima = 10;
    GameObject Dinero;
    public AudioSource Pium;

    // Update is called once per frame
    void Awake()
    {
        Dinero = GameObject.FindGameObjectWithTag("Dinero");
        LayerEnemigos = LayerMask.GetMask("Enemigo");
        TiempoParaElDisparo = 1 / DisparosPorSegundo;
    }
    private void Start()
    {
        municion = municionMaxima;
    }
    void Update()
    {
        RaycastHit2D[] Hit = Physics2D.RaycastAll(transform.position, Vector2.up * Mathf.Sin(transform.eulerAngles.z * Mathf.PI / 180) + Vector2.right * Mathf.Cos(transform.eulerAngles.z * Mathf.PI / 180), Mathf.Infinity, LayerEnemigos);
        ApuntarEnemigoCercano();
        Disparar(Hit);
    }
    void Disparar(RaycastHit2D[] Hit)
    {
        
        if (municion > 0)
        {
            TiempoParaElDisparo -= Time.deltaTime;
            if (TiempoParaElDisparo <= 0)
            {
                TiempoParaElDisparo = 1 / DisparosPorSegundo;
                
                if (Hit.Length != 0)
                {
                    GameObject clon = Instantiate(Bala);
                    clon.transform.position = transform.position;
                    clon.transform.eulerAngles = transform.eulerAngles;
                    Hit[0].collider.gameObject.GetComponent<Enemigo>().HacerDaño(Damage);
                    --municion;
                    
                }
            }
        }
    }
    void ApuntarEnemigoCercano()
    {
        GameObject[] Enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
        GameObject EnemigoCercano;
        if (Enemigos.Length > 0)
        {
            EnemigoCercano = Enemigos[0];
            for (int i = 0; i < Enemigos.Length; ++i)
            {
                //Debug.Log(Vector3.Distance(transform.position, Enemigos[i].transform.position)+" "+Enemigos[1].transform.position);
                if (Vector2.Distance(transform.position, EnemigoCercano.transform.position) > Vector2.Distance(transform.position, Enemigos[i].transform.position))
                {
                    EnemigoCercano = Enemigos[i];
                    
                }

            }
            if (Vector2.Distance(transform.position, EnemigoCercano.transform.position) < rango)
            {
                GirarHaciaObjeto(EnemigoCercano.transform.position);
                if (name == "ThompsonFuncionamiento(Clone)")
                {
                    SpriteTorreta.GetComponent<Animator>().SetBool("EnemigosEnRango", true);
                }
            }
        }
    }
    void GirarHaciaObjeto(Vector2 PosicionALaQueMirar)
    {

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Mathf.Atan2((PosicionALaQueMirar.y - transform.position.y), (PosicionALaQueMirar.x - transform.position.x)) * 180 / Mathf.PI);
    }
    private void OnTouchDown()
    {
        if (municion == 0)
        {
            municion = municionMaxima;
            Dinero.GetComponent<Dinero>().QuitaDinero(precioDeMunMaxima);
        }
    }
}

