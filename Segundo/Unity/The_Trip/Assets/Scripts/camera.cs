using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class camera : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject player;
   //public Vector3 velocidad;
    public Vector3 posicion;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //velocidad.x = 0;
        //velocidad.z = 0;
        posicion.x = gameObject.transform.position.x;
        posicion.z = gameObject.transform.position.z;
    }
    
    // Update is called once per frame
    void Update()
    {
        posicion.y = player.transform.position.y;

        if (player.transform.position.y > gameObject.transform.position.y)
        {
            gameObject.transform.position = posicion;
        }
        
        
        
        
        
        /*if(player.GetComponent<Rigidbody2D>().velocity.y > -1)
        {
            velocidad.y = (player.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            velocidad.y = 0;
        }
        posicion.x = 0;
        posicion.z = -10;
        if (player.GetComponent<Rigidbody2D>().velocity.y > 7)
        {
            posicion.y = player.transform.position.y;
            gameObject.transform.position = posicion;
        }*/
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Plataforma")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
