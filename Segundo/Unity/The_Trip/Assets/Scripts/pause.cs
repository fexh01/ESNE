using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public GameObject play;
    public GameObject paused;
    public Sprite mute;
    public Sprite unmute;
    public GameObject musica;

    void Start()
    {
        
    }

    public void DestroyMusic()
    {
        musica = GameObject.Find("ControladorVolumen");
        Destroy(musica);
    }

    public void ShowPlay()
    {
        Time.timeScale = 1;
        play.SetActive(true);
        paused.SetActive(false);
    }

    public void ShowPause()
    {
        Time.timeScale = 0;
        play.SetActive(false);
        paused.SetActive(true);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    void Update()
    {
        
    }
}
