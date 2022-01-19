using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public int nivel;
    public GameObject musica;
    public Volumen controlador;
    
    // Start is called before the first frame update
    void Start()
    {
        controlador = GameObject.Find("ControladorVolumen").GetComponent<Volumen>();
    }
    public void NextScene()
    {
        if(controlador.nivel < 3)
        {
            SceneManager.LoadScene(controlador.nivel + 2);
        }
        else
        {
            DestroyMusic();
            SceneManager.LoadScene("Menu");
        }
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Play()
    {
        SceneManager.LoadScene("LevelMenu");
    }
    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void GoToLevel()
    {
        SceneManager.LoadScene(nivel + 2);
        controlador.nivel = nivel;
    }

    public void DestroyMusic()
    {
        musica = GameObject.Find("ControladorVolumen");
        Destroy(musica);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
