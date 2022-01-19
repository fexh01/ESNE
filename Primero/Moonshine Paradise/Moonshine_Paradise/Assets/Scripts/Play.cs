using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public SpriteRenderer srPausa;
    public BoxCollider bcPausa;
    private SpriteRenderer sr;
    private BoxCollider bc;
    // Start is called before the first frame update
    void Start()
    {
        bc = gameObject.GetComponent<BoxCollider>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTouchDown()
    {
        Reanudar();
    }

    public void Reanudar()
    {
        bc.enabled = false;
        sr.enabled = false;
        bcPausa.enabled = true;
        srPausa.enabled = true;
        Time.timeScale = 1;
    }

    public void ReanudarOpciones()
    {
        bcPausa.enabled = true;
        srPausa.enabled = true;
        Time.timeScale = 1;
    }
}
