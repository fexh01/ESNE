using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class victoria : MonoBehaviour
{
    public Collider2D coll;
    public AudioSource sonido;
    public bool activado = false;
    public float time = 1;
    public Volumen controlador;


    void Start()
    {
        controlador = GameObject.Find("ControladorVolumen").GetComponent<Volumen>();
    }

    void Update()
    {
        if (activado)
        {
            time = time - Time.deltaTime;
            if (time <= 0)
            {
                controlador.nivel = controlador.nivel + 1;
                SceneManager.LoadScene("Victoria");
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sonido.Play();
            activado = true;
            collision.gameObject.GetComponent<Player>().rb.simulated = false;
        }
    }
}
