using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molotov : MonoBehaviour
{
    Rigidbody2D Rb;
    float EjeY = 0;
    [HideInInspector]
    public float velocidad;
    float MomentoPico;
    [HideInInspector]
    public float Gravedad;
    float TiempoEnElAire = 0;
    float Tamanio;
    [HideInInspector]
    public float RadioDeDanio;
    [HideInInspector]
    public int Damage;

    public AudioSource SCristal;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        MomentoPico = Mathf.Pow(velocidad, 2) / (2 * Gravedad);
        Tamanio = transform.localScale.x;
    }
    void Update()
    {
        SimularParabola();
        if (EjeY <= 0)
        {
            explosion();
            Destroy(gameObject);
        }
    }
    void SimularParabola()
    {
        TiempoEnElAire += Time.deltaTime;
        EjeY = -Gravedad * Mathf.Pow(TiempoEnElAire, 2) + velocidad * TiempoEnElAire;
        transform.localScale = Vector3.one * (Tamanio + (EjeY / MomentoPico) * Tamanio);
    }
    void explosion()
    {
        GameObject[] Enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
        for (int i = 0; i < Enemigos.Length; ++i)
        {
            if (Vector2.Distance(transform.position, Enemigos[i].transform.position) <= RadioDeDanio)
            {
                Enemigos[i].GetComponent<Enemigo>().HacerDaño(Damage);
                Instantiate(SCristal);
            }
        }
    }
}