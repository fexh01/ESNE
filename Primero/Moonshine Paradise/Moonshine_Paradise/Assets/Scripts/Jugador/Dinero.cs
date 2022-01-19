using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinero : MonoBehaviour
{
    public int dineroInicial;
    private int dineroActual;
    public float intervaloDinero;
    private float timer;
    public int incrementoDinero;

    void Start()
    {
        dineroActual = dineroInicial;
        if (intervaloDinero == 0)
            intervaloDinero = 1;
        timer = intervaloDinero;
            
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <=0)
        {
            dineroActual += incrementoDinero;
            timer = intervaloDinero;
        }
        ActualizarDinero();
    }

    public bool QuitaDinero(int cantidad)
    {
        if (dineroActual-cantidad>=0)
        {
            dineroActual -= cantidad;
            ActualizarDinero();
            return true;
        }
        else
        {
            return false;
        }
        
    }
    public void SumaDinero(int cantidad)
    {
        dineroActual += cantidad;
        ActualizarDinero();
    }
    private void ActualizarDinero()
    {
        gameObject.GetComponent<UnityEngine.UI.Text>().text = dineroActual.ToString();
    } 
}
