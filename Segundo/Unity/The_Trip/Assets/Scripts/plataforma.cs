using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma : MonoBehaviour
{
    BoxCollider2D coll;
    public Player player;
    public bool desaparece = false;
    public bool movil = false;
    public int vel = 1;
    public bool pinchos = false;
    public bool superSalto = false;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(movil == true)
        {
            if (gameObject.transform.position.x > 3 || gameObject.transform.position.x < -3)
            {
                vel = vel * (-1);
            }

            Vector3 position;
            position.x = gameObject.transform.position.x + (0.01f * vel);
            position.y = gameObject.transform.position.y;
            position.z = gameObject.transform.position.z;
            gameObject.transform.position = position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (desaparece == true)
        {
            //gameObject.SetActive(false);
            animator.SetBool("JumpedOn", true);
        }

        if (pinchos == true)
        {
            player.vida = player.vida-1;
        }
    }
}
