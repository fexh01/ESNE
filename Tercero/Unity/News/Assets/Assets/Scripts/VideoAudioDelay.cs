using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoAudioDelay : MonoBehaviour
{
    public AudioSource audioSource;
    public float timer;
    public bool playing;

    // Start is called before the first frame update
    void Start()
    {
        playing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer = timer - Time.deltaTime;
        }
        else
        {
            if (!playing)
            {
                audioSource.Play();
                playing = true;
            }
            
        }
    }
}
