using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
    public GameObject player;
    public GameObject TpTo;
    public PlayerMovement playerMV;
    public CharacterController ChControl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMV.enabled == false)
        {
            playerMV.enabled = true;
        }
        if (ChControl.enabled == false)
        {
            ChControl.enabled = true;
        }
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            ChControl.enabled = false;
            playerMV.enabled = false;
            player.transform.position = TpTo.transform.position;
            player.transform.rotation = TpTo.transform.rotation;
        }
    }
}
