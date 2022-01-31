using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Receptor : MonoBehaviour
{
    public bool active;
    public bool makeSound;
    public bool puerta;
    public bool puzzle1;
    public bool end;
    public GameObject endMenu;
    public int timer = 2;

    AudioSource audioSource;

    public AudioClip unlockDoorSound;

    // Start is called before the first frame update
    void Start()
    {
        makeSound = false;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (end)
        {
            if (active)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                endMenu.SetActive(true);
            }
        }

        if (puerta)
        {
            switch (active)
            {
                case true:

                    gameObject.GetComponent<puerta>().locked = false;
                    if (makeSound)
                    {
                        audioSource.clip = unlockDoorSound;
                        audioSource.Play();
                        makeSound = false;
                    }

                    break;

                case false:

                    gameObject.GetComponent<puerta>().locked = true;

                    if (makeSound)
                    {
                        audioSource.clip = unlockDoorSound;
                        audioSource.Play();
                        makeSound = false;
                    }

                    break;
            }
        }
        else
        {
            if (active && !puerta && puzzle1)
            {
                if (timer > 0)
                {
                    --timer;
                }
                else
                {
                    active = false;
                    timer = 2;
                }
                
            }
        }
    }
}
