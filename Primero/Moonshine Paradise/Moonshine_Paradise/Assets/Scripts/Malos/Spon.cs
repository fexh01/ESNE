using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using PathCreation;
using PathCreation.Examples;
using UnityEngine.SceneManagement;

public class Spon : MonoBehaviour
{
    public GameObject controlador;
    public PathCreator path;
    //public GameObject[] enemigo;
    public Transform spawn;
    [System.Serializable]
    public struct oleada
    {
        public arrEnemigos[] enemigo;
    }
    [System.Serializable]
    public struct arrEnemigos
    {
        public GameObject zombie;
        public int nZombie;
    }

    //public arrEnemigos[] enemigo;
    public oleada[] oleadas;
    private static int numOleada = 0;
    //private static bool nuevaOleada = true;
    private arrEnemigos[] oleadaActual;
    private static bool lvlCompletado = false;

    private int rand; //Tipo de zombie que saca
    private int nMobs = 0; //Nº mobs que saca

    public float empezarContador; //Tiempo entre tandas de zombies
    private float contador;
    public float reguladorSpawnInicio; //Tiempo entre zombies
    private float reguladorSpawn;
    private int[] vidas = new int[3];
    public int totalzombies { get; private set; }

    

    // Start is called before the first frame update
    void Start()
    {
        setOleadaActual(numOleada);
        /*if (nuevaOleada)
        {
            setOleadaActual(numOleada);
            nuevaOleada = false;
        }*/
        contador = empezarContador;
        reguladorSpawn = reguladorSpawnInicio;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (contador <= 0 && totalzombies > 0)
        {
            if (nMobs == 0)
            {
                rand = Random.Range(0, oleadaActual.Length);
                nMobs = Random.Range(1, 5);
            }
                
            if (reguladorSpawn <= 0 && nMobs > 0 && oleadaActual[rand].nZombie>0)
            {
                GameObject clon = Instantiate(oleadaActual[rand].zombie);
                clon.GetComponent<Enemigo>().setControlador(controlador);
                clon.transform.position = spawn.transform.position;
                clon.GetComponent<PathFollower>().setPath(path);
                --nMobs;
                --totalzombies;
                oleadaActual[rand].nZombie -= 1;
                reguladorSpawn = reguladorSpawnInicio;
                //Debug.Log(totalzombies + " " + gameObject.name);
            }
            else if (oleadaActual[rand].nZombie == 0)//Arreglar el timing de spawn una vez se acaba un tipo de zombie
            {
                nMobs = 0;
            }

            reguladorSpawn -= Time.deltaTime;

            if (nMobs == 0)
            {
                contador = empezarContador;
                     
            }

                
                
        }
        else
        {
            contador -= Time.deltaTime;
            
        }

        if(TotalZombies.totalZombies == 0)
        {
            //Debug.Log(totalzombies);
            if (numOleada < oleadas.Length-1)
            {
                ++numOleada;
                setOleadaActual(numOleada);
                //Debug.Log(numOleada);
            }
            else if(!lvlCompletado)
            {
                //Debug.Log(lvlCompletado);
               
                MenuPrincipal.DineroGlobal += (int)controlador.GetComponent<Controlador>().vida.vidaBar;
                TotalZombies.WinLvl();
                lvlCompletado = true;
            }
        }
            
    }

    private void setOleadaActual(int numOleada)
    {
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
        for(int i = 0; i < spawners.Length; ++i)
        {
            Spon spawner = spawners[i].GetComponent<Spon>();
            spawner.oleadaActual = spawner.oleadas[numOleada].enemigo;
        }
        actualizarContador();

    }

    private void actualizarContador()
    {
        if(TotalZombies.totalZombies == 0)
        {
            GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
            for (int i = 0; i < spawners.Length; ++i)
            {
                Spon spawner = spawners[i].GetComponent<Spon>();
                //Debug.Log(spawner.oleadaActual.Length);
                for (int j = 0; j < spawner.oleadaActual.Length; ++j)
                {
                    spawner.totalzombies += spawner.oleadaActual[j].nZombie;
                    //Debug.Log(spawner.totalzombies + " " + TotalZombies.totalZombies);
                    //Debug.Log(spawner.oleadaActual[j].nZombie + " " + gameObject.name);
                }
                TotalZombies.totalZombies += spawner.totalzombies;
                //Debug.Log(spawner.totalzombies+" "+TotalZombies.totalZombies);
            }
        }
        
    }


}

