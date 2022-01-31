using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Puzzle1TV : MonoBehaviour
{
    public bool encendida;
    public GameObject palabra;
    public GameObject apagada;

    // Start is called before the first frame update
    void Start()
    {
        encendida = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (encendida)
        {
            palabra.SetActive(true);
            apagada.SetActive(false);
        }
        else
        {
            palabra.SetActive(false);
            apagada.SetActive(true);
        }
    }
}
