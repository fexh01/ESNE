using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocarTorreta : MonoBehaviour
{
    public bool puedeMatones = true;
    // Start is called before the first frame update
    private GameObject spriteTorreta;
    private GameObject torreta;
    private GameObject torretaSpriteInstance;
    private GameObject torretaInstance;
    private SpriteRenderer sr;
    private bool colocarTorreta = false;
    public GameObject dinero;
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        //dinero = GameObject.FindGameObjectWithTag("Dinero");
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTouchDown()
    {
        //sr.color += new Color(0,0,0,100);
        if (colocarTorreta && spriteTorreta.GetComponent<ComprobarPago>().Comprobar(dinero))
        {
            Destroy(torretaInstance);
            Destroy(torretaSpriteInstance);
            GameObject clon;
            GameObject Temporal = new GameObject();
            if (torreta.gameObject!=null)
            {
                clon = Instantiate(torreta);
                clon.transform.position = gameObject.transform.position;
                Temporal = clon;
                torretaInstance = clon;
            }
            clon = Instantiate(spriteTorreta);
            if (Temporal.GetComponent<Thompson>() != null)
            {
                Temporal.GetComponent<Thompson>().SpriteTorreta = clon;
            }
            clon.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y+0.2f,gameObject.transform.position.z);
            torretaSpriteInstance = clon;
            GameObject[] botonesTorretas = GameObject.FindGameObjectsWithTag("botonTorreta");
            GameObject boton;
            for (int i = 0;i<botonesTorretas.Length; ++i)
            {  
                boton = botonesTorretas[i];
                if (i == 0)
                {
                    boton.GetComponent<ActivarTorreta>().limpiar();
                    
                }   
                boton.GetComponent<ActivarTorreta>().reset();
            }
            /*foreach (GameObject boton in botonesTorretas)
            {
                boton.GetComponent<ActivarTorreta>().reset();
            }*/
        }
        
    }

    public void setTorreta(GameObject torreta)
    {
        this.torreta = torreta;
    }

    public void setTorretaSprite(GameObject sprite)
    {
        spriteTorreta = sprite;
    }

    public void setColocarTorreta(bool estado)
    {
        colocarTorreta = estado;
    }
}
