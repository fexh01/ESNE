using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opciones : MonoBehaviour
{
    public GameObject panelOpciones;
    public Pausa botonPausa;
    public Play botonPlay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTouchDown()
    {
        panelOpciones.SetActive(true);
        botonPausa.PausaOpciones();
        DesactivarColliders();
    }

    public void Reanudar()
    {
        panelOpciones.SetActive(false);
        botonPlay.ReanudarOpciones();
        ActivarColliders();
    }

    private void DesactivarColliders()
    {
        Collider[] colliders = GameObject.FindObjectsOfType<Collider>();
        for (int i=0;i<colliders.Length;++i)
        {
            colliders[i].enabled = false;
        }
    }

    private void ActivarColliders()
    {
        Collider[] colliders = GameObject.FindObjectsOfType<Collider>();
        for (int i = 0; i < colliders.Length; ++i)
        {
            colliders[i].enabled = true;
        }
    }
}
