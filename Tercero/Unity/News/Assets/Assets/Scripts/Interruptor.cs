using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{
    public bool active;
    public GameObject target;
    public bool reusable;
    public bool used;
    public GameObject encendido;
    public GameObject apagado;

    public GameObject alerta;
    public bool canBeUsed;

    AudioSource audioSource;

    public float tiempo = 2;
    public float tiempoActual;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        alerta = GameObject.Find("Interruptor").GetComponent<Interruptor>().alerta;
        encendido.SetActive(false);
        apagado.SetActive(true);
        alerta.SetActive(false);
        canBeUsed = false;
        active = false;
        used = false;
        tiempoActual = tiempo;
    }

    // Update is called once per frame
    void Update()
    {
        if (canBeUsed && Input.GetKeyDown(KeyCode.E))
        {
            if (reusable)
            {
                tiempoActual = tiempo;
                encendido.SetActive(true);
                apagado.SetActive(false);
                target.gameObject.GetComponent<Receptor>().active = true;
                target.gameObject.GetComponent<Receptor>().makeSound = true;
                audioSource.Play();


                /*if (active)
                {
                    active = false;
                    target.gameObject.GetComponent<Receptor>().active = false;
                    target.gameObject.GetComponent<Receptor>().makeSound = true;
                    encendido.SetActive(false);
                    apagado.SetActive(true);
                    audioSource.Play();
                }
                else
                {
                    active = true;
                    target.gameObject.GetComponent<Receptor>().active = true;
                    target.gameObject.GetComponent<Receptor>().makeSound = true;
                    encendido.SetActive(true);
                    apagado.SetActive(false);
                    audioSource.Play();
                    active = false;
                }*/
            }
            else
            {
                if (!used)
                {
                    encendido.SetActive(true);
                    apagado.SetActive(false);
                    active = true;
                    target.gameObject.GetComponent<Receptor>().active = true;
                    target.gameObject.GetComponent<Receptor>().makeSound = true;
                    used = true;
                    active = false;
                    alerta.SetActive(false);
                    audioSource.Play();
                }
            }

        }

        if (reusable)
        {
            if (encendido.activeSelf)
            {
                if (tiempoActual > 0)
                {
                    tiempoActual = tiempoActual - Time.deltaTime;
                }
                else
                {
                    encendido.SetActive(false);
                    apagado.SetActive(true);
                    tiempoActual = tiempo;
                }
            }
        }
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player" && (reusable || !used))
        {
            alerta.SetActive(true);
            canBeUsed = true;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            alerta.SetActive(false);
            canBeUsed = false;
        }
    }
}
