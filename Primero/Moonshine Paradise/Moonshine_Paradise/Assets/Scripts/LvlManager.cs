using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LvlManager : MonoBehaviour
{
    // Start is called before the first frame update

    
    public Button[] Botoneslvl;

    
    void Start()
    {

        int LvlAlcanzado = PlayerPrefs.GetInt("Lvl Alcanzado", 1);
        int dineroAVida = PlayerPrefs.GetInt("dineroAVida", 0);
        Debug.Log(LvlAlcanzado);
        for (int i = 0; i < Botoneslvl.Length ; i++)
        {
            if (i  >= LvlAlcanzado)
            {
                
                Botoneslvl[i].interactable = false;
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    
}
