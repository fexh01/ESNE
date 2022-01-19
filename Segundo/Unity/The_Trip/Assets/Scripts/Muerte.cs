using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Muerte : MonoBehaviour
{
    public float time = 1;
    public AudioSource sonido;
    public bool activado = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activado)
        {
            time = time - Time.deltaTime;
            if (time <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            activado = true;
            collision.GetComponent<Player>().rb.simulated = false;
            sonido.Play();
        }
    }
}
