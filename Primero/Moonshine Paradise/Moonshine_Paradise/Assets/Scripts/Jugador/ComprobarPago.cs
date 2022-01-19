using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprobarPago : MonoBehaviour
{
    public int coste;
    // Start is called before the first frame update
    public bool Comprobar(GameObject dinero)
    {
        return dinero.GetComponent<Dinero>().QuitaDinero(coste);
            
    }
}
