using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apagar : MonoBehaviour
{
    public BoxCollider2D coll;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            coll.isTrigger = true;
        }
    }
}
