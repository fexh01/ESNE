using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D colision;
    public int direccion;
    public Vector3 movimiento;
    public Vector3 escala;
    public AudioSource sonido;
    public bool giro = false;
    
    void Start()
    {
        movimiento.y = 0;
        movimiento.z = 0;
        escala.y = 1;
        escala.z = 1;
    }

    void Update()
    {
        if(transform.position.x <= -3|| transform.position.x >= 3)
        {
            if (!giro)
            {
                direccion = direccion * (-1);
                escala.x = gameObject.transform.localScale.x * -1;
                gameObject.transform.localScale = escala;
                giro = true;
            }
        }
        else if (transform.position.x > -3 || transform.position.x < 3)
        {
            if (giro)
            {
                giro = false;
            }
        }

        movimiento.x = direccion;

        rb.velocity = movimiento;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if(collision.tag == "Player")
        {
            if(collision.gameObject.GetComponent<Player>().safe == false)
            {
                sonido.Play();
                direccion = 0;
                rb.velocity = new Vector2(0, 0);
                collision.gameObject.GetComponent<Player>().vida = 0;
                rb.simulated = false;
            } 
        }
    }
}
