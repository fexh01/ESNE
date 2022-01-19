using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;
using UnityEngine.UI;
using System.Linq;

public class TotalZombies : MonoBehaviour
{
    public static int totalZombies = 0;
    public static GameObject LvlFinito;
    // Start is called before the first frame update
    void Start()
    {
        LvlFinito = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("Winner"));
        //Debug.Log(LvlFinito.name);
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
        /*foreach (GameObject spawner in spawners)
        {
            totalZombies += spawner.GetComponent<Spon>().totalzombies;
        }*/
        
    }

    private void Update()
    {

        ActualizarZombies();
        //WinLvl();
    }

    private void ActualizarZombies()
    {
        GetComponent<Text>().text = totalZombies.ToString();
    }
    public void RestarZombie()
    {
        --totalZombies;
        ActualizarZombies();
    }

    public static void WinLvl ()
    {
        if (totalZombies <= 0 && !LvlFinito.activeInHierarchy)
        {
            //Debug.Log("Winner Winner Chicken Dinner");
            LvlFinito.SetActive(true);
            PlayerPrefs.SetInt("LvlAlcanzado", 2);
        }
    }
}
