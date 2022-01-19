using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    public Dinero dinero;
    public TotalZombies cz;
    public Vida vida;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ZombieMuerto(int dineroExtra)
    {
        dinero.SumaDinero(dineroExtra);
        cz.RestarZombie();
    }
}
