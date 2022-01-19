using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edificio : MonoBehaviour
{
    // Start is called before the first frame update
    private int collisionCount = 0;
    private SpriteRenderer sr;
    public bool visible = true;
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (visible&&sr!=null)
        {
            visible = false;
            sr.color -= new Color(0,0,0,0.4f);
        }
            
        collisionCount++;
     
    }

    void OnTriggerExit2D(Collider2D col)
    {
        collisionCount--;
        if (collisionCount == 0 && sr != null)
        {
            visible = true;
            sr.color += new Color(0,0,0,0.4f);
        }
            
     }

}
