using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public bool superSalto;
    public bool escudo;
    public AudioSource sonido;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (superSalto)
        {
            if(collision.gameObject.tag == "Player")
            {
                sonido.Play();
                Player player = collision.gameObject.GetComponent<Player>();
                player.rb.AddForce(player.impulso * player.potencia / 2, ForceMode2D.Impulse);
                gameObject.SetActive(false);
            }
        }
        else if (escudo)
        {
            if (collision.gameObject.tag == "Player")
            {
                sonido.Play();
                Player player = collision.gameObject.GetComponent<Player>();
                player.escudos.SetActive(true);
                player.safe = true;
                gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (superSalto)
        {
            if (collision.gameObject.tag == "Player")
            {
                sonido.Play();
                Player player = collision.gameObject.GetComponent<Player>();
                player.rb.AddForce(player.impulso * player.potencia / 2, ForceMode2D.Impulse);
                gameObject.SetActive(false);
            }
        }
        else if (escudo)
        {
            if (collision.gameObject.tag == "Player")
            {
                sonido.Play();
                Player player = collision.gameObject.GetComponent<Player>();
                player.escudos.SetActive(true);
                player.safe = true;
                gameObject.SetActive(false);
            }
        }
    }

}
