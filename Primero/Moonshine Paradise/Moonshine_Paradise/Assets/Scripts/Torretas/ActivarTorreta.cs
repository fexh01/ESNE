using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarTorreta : MonoBehaviour
{
    public static bool TorretaPistolaDesbloqueada = true;
    public static bool TorretaMatonesDesbloqueado = true;
    public static bool TorretaMolotovDesbloqueado = false;
    public static bool TorretaThompsonDesbloqueado = false;
    public bool activo = false;
    public GameObject spriteTorreta;
    public GameObject torreta;
    public GameObject[] tiles;

    public AudioSource STorreta;

    // Start is called before the first frame update
    void Start()
    {
        tiles = GameObject.FindGameObjectsWithTag("tileTorreta");
        comprobarBoton();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTouchDown()
    {
        if (torreta.gameObject.GetComponent<Torreta>() != null)
        {
            
            PonerTorreta();
           
            
           
        }
        else if (torreta.gameObject.GetComponent<Torreta_Matones>() != null)
        {
            PonerTorreta();
        }
        else if (torreta.gameObject.GetComponent<Mortero>() != null)
        {
            if (TorretaMolotovDesbloqueado)
            {
                PonerTorreta();
                
            }
        }
        else if (torreta.gameObject.GetComponent<Thompson>() != null)
        {
            if (TorretaThompsonDesbloqueado)
            {
                PonerTorreta();
            }
        }
    }

    public void limpiar()
    {
        foreach (GameObject tile in tiles)
        {
            if(tile.GetComponent<SpriteRenderer>().color.a >= 255)
                tile.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 255);
            tile.GetComponent<ColocarTorreta>().setTorreta(null);
            tile.GetComponent<ColocarTorreta>().setTorretaSprite(null);
            tile.GetComponent<ColocarTorreta>().setColocarTorreta(false);
            tile.GetComponent<BoxCollider>().enabled = false;
        }
    }
    public void reset()
    {
        activo = false;
    }
    void PonerTorreta()
    {
        if (activo == false)
        {
            //Debug.Log("Hola");
            foreach (GameObject tile in tiles)
            {
                if(tile.GetComponent<ColocarTorreta>().puedeMatones && torreta.gameObject.GetComponent<Torreta_Matones>() != null)
                {
                    instanciarTorreta(tile);

                } 
                else if (tile.GetComponent<SpriteRenderer>().color.a < 255 && torreta.gameObject.GetComponent<Torreta_Matones>() == null)
                {
                    instanciarTorreta(tile);
                }
                
            }
            activo = true;
        }
        else
        {
            //Debug.Log("Hola");
            limpiar();
            reset();
        }
    }

    private void instanciarTorreta(GameObject tile)
    {
        tile.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 255);
        tile.GetComponent<ColocarTorreta>().setTorreta(torreta);
        tile.GetComponent<ColocarTorreta>().setTorretaSprite(spriteTorreta);
        tile.GetComponent<ColocarTorreta>().setColocarTorreta(true);
        tile.GetComponent<BoxCollider>().enabled = true;
        Instantiate(STorreta);
    }

    private void comprobarBoton() {
        switch (spriteTorreta.name)
        {
            case "Torreta_molotov":
                if(TorretaMolotovDesbloqueado)
                {
                    activarBoton();
                }
                break;
            case "TorretaThopmson":
                if (TorretaThompsonDesbloqueado)
                {
                    activarBoton();
                }
                break;
        }
        
    }
    private void activarBoton()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
