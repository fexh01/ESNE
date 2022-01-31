using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2 : MonoBehaviour
{
    public GameObject puerta7;
    public GameObject puerta8;
    public GameObject puerta9;
    public GameObject puerta10;
    public GameObject puerta11;
    public GameObject puerta12;
    public GameObject puerta13;
    public GameObject puerta14;
    public GameObject puerta15;
    public GameObject puerta16;
    public GameObject puerta17;
    public GameObject puerta18;
    public GameObject puerta19;
    public GameObject puerta20;

    public Receptor interruptor6;
    public Receptor interruptor7;
    public Receptor interruptor8;
    public Receptor interruptor9;
    public Receptor interruptor10;
    public Receptor interruptor11;
    public Receptor interruptor12;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interruptor6.active)
        {
            if (puerta9.activeSelf)
            {
                puerta9.SetActive(false);
            }
            else
            {
                puerta9.SetActive(true);
            }

            if (puerta12.activeSelf)
            {
                puerta12.SetActive(false);
            }
            else
            {
                puerta12.SetActive(true);
            }

            interruptor6.active = false;
        }

        if (interruptor7.active)
        {
            if (puerta13.activeSelf)
            {
                puerta13.SetActive(false);
            }
            else
            {
                puerta13.SetActive(true);
            }

            if (puerta16.activeSelf)
            {
                puerta16.SetActive(false);
            }
            else
            {
                puerta16.SetActive(true);
            }

            puerta12.SetActive(true);

            interruptor7.active = false;
        }

        if (interruptor8.active)
        {
            if (puerta11.activeSelf)
            {
                puerta11.SetActive(false);
            }
            else
            {
                puerta11.SetActive(true);
            }

            if (puerta16.activeSelf)
            {
                puerta16.SetActive(false);
            }
            else
            {
                puerta16.SetActive(true);
            }

            if (puerta19.activeSelf)
            {
                puerta19.SetActive(false);
            }
            else
            {
                puerta19.SetActive(true);
            }

            interruptor8.active = false;
        }

        if (interruptor9.active)
        {
            if (puerta18.activeSelf)
            {
                puerta18.SetActive(false);
            }
            else
            {
                puerta18.SetActive(true);
            }

            if (puerta20.activeSelf)
            {
                puerta20.SetActive(false);
            }
            else
            {
                puerta20.SetActive(true);
            }

            interruptor9.active = false;
        }

        if (interruptor10.active)
        {
            if (puerta8.activeSelf)
            {
                puerta8.SetActive(false);
            }
            else
            {
                puerta8.SetActive(true);
            }

            if (puerta15.activeSelf)
            {
                puerta15.SetActive(false);
            }
            else
            {
                puerta15.SetActive(true);
            }

            interruptor10.active = false;
        }

        if (interruptor11.active)
        {
            if (puerta15.activeSelf)
            {
                puerta15.SetActive(false);
            }
            else
            {
                puerta15.SetActive(true);
            }

            interruptor11.active = false;
        }
    }
}
