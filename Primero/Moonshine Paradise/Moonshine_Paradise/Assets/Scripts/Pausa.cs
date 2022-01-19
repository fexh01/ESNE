using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public SpriteRenderer srPlay;
    public BoxCollider bcPlay;
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

    private void OnTouchDown() {
        Pausar();
    }

    private void Pausar()
    {
        bc.enabled = false;
        sr.enabled = false;
        bcPlay.enabled = true;
        srPlay.enabled = true;
        Time.timeScale = 0;
    }

    public void PausaOpciones()
    {
        bc.enabled = false;
        sr.enabled = false;
        Time.timeScale = 0;
    }
}
