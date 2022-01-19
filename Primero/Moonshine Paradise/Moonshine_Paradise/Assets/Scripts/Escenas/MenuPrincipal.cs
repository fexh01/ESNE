using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject boton1;
    public GameObject boton2;
    public GameObject boton3;
    public GameObject boton4;
    public Text TextoDineroGlobal;
    public static int DineroGlobal = 0;
    public int[] coste;
    public static int[] dineroGanadoNivel;
    void Start()
    {
        ActualizarDinero();
    }
    void Update()
    {
        if (ActivarTorreta.TorretaPistolaDesbloqueada && boton1!=null)
        {
            Destroy(boton1);
        }
        if (ActivarTorreta.TorretaMatonesDesbloqueado && boton2 != null)
        {
            Destroy(boton2);
        }
        if (ActivarTorreta.TorretaMolotovDesbloqueado && boton3 != null)
        {
            Destroy(boton3);
        }
        if (ActivarTorreta.TorretaThompsonDesbloqueado && boton4 != null)
        {
            Destroy(boton4);
        }
    }
    public void IrANivel(string nivel)
    {

        SceneManager.LoadScene(nivel);
    }
    public void ComprarTorreta(int torreta)
    {
        if (torreta == 2)
        {
            if(ComprobarComprarTorreta(coste[1]))
                ActivarTorreta.TorretaMatonesDesbloqueado = true;
            
        }
        else if(torreta == 3)
        {
            if(ComprobarComprarTorreta(coste[2]))
                ActivarTorreta.TorretaMolotovDesbloqueado = true;
        }
        else if(torreta == 4)
        {
            if(ComprobarComprarTorreta(coste[3]))
                ActivarTorreta.TorretaThompsonDesbloqueado = true;
        }
    }

    private bool ComprobarComprarTorreta(int coste)
    {
        if (coste<=DineroGlobal)
        {
            DineroGlobal -= coste;
            ActualizarDinero();
            return true;
        }
        else
            return false;
    }

    public void ActualizarDinero()
    {
        TextoDineroGlobal.text = "Dinero:" + DineroGlobal.ToString();
    }
    public void Salir()
    {
        //Debug.Log("Ta luego");
        Application.Quit();

    }
}
