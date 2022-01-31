using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    float x;
    float z;
    Vector3 move;
    public float verticalPosition;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        verticalPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        Vector3 newPosition = new Vector3(transform.position.x, verticalPosition, transform.position.z);
        transform.position = newPosition;

        if(x != 0 || z != 0)
        {
            audioSource.mute = false;
        }
        if(x == 0 && z == 0)
        {
            audioSource.mute = true;
        }
    }
}
