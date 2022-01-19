using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSides : MonoBehaviour
{
    public GameObject parent;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("VelocidadJugador", parent.GetComponent<Player>().rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            parent.transform.position = gameObject.transform.position;
        }
    }
}
