using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorVida : MonoBehaviour
{
    public Vida Bar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarVida();
    }

    private void ActualizarVida()
    {
        gameObject.GetComponent<UnityEngine.UI.Text>().text = ((int) Bar.vidaBar).ToString();
    }
}
