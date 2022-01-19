using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using System.Linq;


public class Vida : MonoBehaviour
{
    public float vidaBar = 5000f;
    public static GameObject LvlFinito;

    public AudioSource Golpiños;

    // Start is called before the first frame update
    void Start()
    {
        LvlFinito = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("Looser"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            collision.gameObject.GetComponent<Animator>().SetBool("ListoParaPegar", true);
            Instantiate(Golpiños);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (vidaBar <= 0)
        {
            Destroy(gameObject);
            LvlFinito.SetActive(true);


        }
        
    }

}
