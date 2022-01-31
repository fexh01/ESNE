using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TV : MonoBehaviour
{
    public VideoClip[] states;
    public float[] timeBetweenStates;
    public int state;
    public bool start;

    public VideoPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<VideoPlayer>();
        player.clip = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == 0 && player.clip != states[0])
        {
            player.clip = states[state];
        }
        if (start)
        {
            if (timeBetweenStates[state] > 0)
            {
                timeBetweenStates[state] = timeBetweenStates[state] - Time.deltaTime;
            }
            else
            {
                ++state;
                player.clip = states[state];
            }
        }
    }
}
