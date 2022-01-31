using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioSala : MonoBehaviour
{
    public Receptor receptor;
    public GameObject sala1;
    public GameObject sala2;

    // Start is called before the first frame update
    void Start()
    {
        receptor.active = false;
        sala2.SetActive(false);
        sala1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (receptor.active)
        {
            sala1.SetActive(false);
            sala2.SetActive(true);
        }
    }
}

