using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float velocidad = 5f;
    public Vector2 movimiento;
    public Vector2 impulso;
    public float potencia;
    public Rigidbody2D rb;
    public bool dobleSalto = false;
    public int vida = 1;
    public bool choca = false;
    public Animator animator;
    public float dir;
    public float time;
    public AudioSource sonido;
    public GameObject escudos;
    public bool safe = false;
    public float safeTime = 3;

    void Start()
    {
        time = 1;
        rb = GetComponent<Rigidbody2D>();
        impulso.x = 0;
        impulso.y = 1;
    }

    public void SetIzq()
    {
        rb.velocity = new Vector2(0,rb.velocity.y);
        dir = -2.5f;
        //rb.velocity = rb.velocity * (new Vector2(dir, 0))*Time.deltaTime;
    }
    public void SetDcha()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        dir = 2.5f;
        //rb.velocity = rb.velocity * (new Vector2(dir, 0)) * Time.deltaTime;
    }
    void Update()
    {
        if(vida == 0)
        {
            time = time - Time.deltaTime;
            if(time <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }

        if (safe)
        {
            safeTime = safeTime - Time.deltaTime;
            if(safeTime <= 0)
            {
                safe = false;
                escudos.SetActive(false);
                safeTime = 3;
            }
        }

        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.x = movimiento.x / (20/velocidad);
        movimiento.y = 0;

        rb.velocity = new Vector2(dir, rb.velocity.y);

        animator.SetFloat("VelocidadJugador", rb.velocity.y);
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            if(dobleSalto == true)
            {
                dobleSalto = false;
                rb.AddForce(impulso * potencia, ForceMode2D.Impulse);
            }
        }*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plataforma")
        {   
            if (collision.gameObject.GetComponent<plataforma>().superSalto == false)
            {
                rb.AddForce(impulso * potencia, ForceMode2D.Impulse);
            }

            if (collision.gameObject.GetComponent<plataforma>().superSalto == true)
            {
                rb.AddForce(impulso * potencia * 2, ForceMode2D.Impulse);
            }

            sonido.Play();
            animator.SetBool("TocaPlataforma", true);

        }

        if (collision.gameObject.tag == "Enemigo")
        {
            if (!safe)
            {
                vida = 0;
                rb.simulated = false;
                collision.gameObject.GetComponent<Enemigo>().rb.simulated = false;
                collision.gameObject.GetComponent<Enemigo>().rb.velocity = new Vector2(0, 0);
                collision.gameObject.GetComponent<Enemigo>().direccion = 0;
                collision.gameObject.GetComponent<Enemigo>().sonido.Play();
            } 
        }

        if (collision.gameObject.tag == "PowerUp")
        {
            if (collision.gameObject.GetComponent<PowerUps>().superSalto == true)
            {
                collision.gameObject.GetComponent<PowerUps>().sonido.Play();
                rb.AddForce(impulso * potencia / 2, ForceMode2D.Impulse);
                collision.gameObject.SetActive(false);
            }
            else if (collision.gameObject.GetComponent<PowerUps>().escudo == true)
            {
                collision.gameObject.GetComponent<PowerUps>().sonido.Play();
                escudos.SetActive(true);
                safe = true;
                collision.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DobleSalto")
        {
            dobleSalto = true;
        }

        if (collision.gameObject.tag == "Plataforma")
        {
            choca = true;
        }

        if (collision.gameObject.GetComponent<plataforma>().superSalto == true)
        {
            rb.AddForce(impulso * potencia, ForceMode2D.Impulse);
        }

        if(collision.gameObject.tag == "PowerUp")
        {
            if(collision.gameObject.GetComponent<PowerUps>().superSalto == true)
            {
                collision.gameObject.GetComponent<PowerUps>().sonido.Play();
                rb.AddForce(impulso * potencia / 2, ForceMode2D.Impulse);
                collision.gameObject.SetActive(false);
            }
            else if (collision.gameObject.GetComponent<PowerUps>().escudo == true)
            {
                collision.gameObject.GetComponent<PowerUps>().sonido.Play();
                escudos.SetActive(true);
                safe = true;
                collision.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plataforma")
        {
            choca = false;
        }
    }

}
