using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puerta : MonoBehaviour
{
    public GameObject abierta;
    public GameObject cerrada;
    public bool closed;
    public bool locked;
    public bool canBeUsed;
    public GameObject alerta;
    public bool puzzle1;

    public AudioSource audioSource;

    public AudioClip openDoorSound;
    public AudioClip closeDoorSound;
    public AudioClip lockedDoorSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        alerta = GameObject.Find("Interruptor").GetComponent<Interruptor>().alerta;
        alerta.SetActive(false);
        canBeUsed = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (closed)
        {
            case true:

                cerrada.SetActive(true);
                abierta.SetActive(false);

                break;

            case false:

                cerrada.SetActive(false);
                abierta.SetActive(true);

                break;
        }

        if(canBeUsed && Input.GetKeyDown(KeyCode.E))
        {
            if (locked)
            {
                audioSource.clip = lockedDoorSound;
                audioSource.Play();
            }
            else
            {
                if (closed)
                {
                    audioSource.clip = openDoorSound;
                    audioSource.Play();
                    closed = false;
                }
                else
                {
                    audioSource.clip = closeDoorSound;
                    audioSource.Play();
                    closed = true;
                }
            }
        }
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            if (!puzzle1)
            {
                alerta.SetActive(true);
                canBeUsed = true;
            }
            
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            alerta.SetActive(false);
            canBeUsed = false;
        }
    }
}
