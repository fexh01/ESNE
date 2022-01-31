using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public bool active;
    public bool used;
    public AudioSource audioSource;
    public float tiempo = 5;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        audioSource = gameObject.GetComponent<AudioSource>();
        used = false;
        audioSource.mute = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (active && !used)
        {
            audioSource.mute = false;
            used = true;
        }
        else
        {
            if (used)
            {
                if (tiempo > 0)
                {
                    tiempo = tiempo - Time.deltaTime;
                }
                else
                {
                    if(audioSource.volume > 0 && audioSource.mute == false)
                    {
                        audioSource.volume = (float)(audioSource.volume - 0.0005);
                    }
                    else
                    {
                        audioSource.mute = true;
                        audioSource.volume = 0.11f;
                    }
                    
                }
            }
        }
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            active = true;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            active = false;
        }
    }
}
