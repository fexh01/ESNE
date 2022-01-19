using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLvl : MonoBehaviour
{

    public void NextLvl ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        if (SceneManager.GetActiveScene().buildIndex == 1 || PlayerPrefs.Equals("Lvl Alcanzado", 1))
        {
            PlayerPrefs.SetInt("Lvl Alcanzado", 2);
        }

        if (SceneManager.GetActiveScene().buildIndex == 2 || PlayerPrefs.Equals("Lvl Alcanzado", 2))
        {
            PlayerPrefs.SetInt("Lvl Alcanzado", 3);
        }
    }

    public void MenuWin()
    {
        SceneManager.LoadScene(0);

        if (SceneManager.GetActiveScene().buildIndex == 1 || PlayerPrefs.Equals("Lvl Alcanzado", 1))
        {
            PlayerPrefs.SetInt("Lvl Alcanzado", 2);
        }

        if (SceneManager.GetActiveScene().buildIndex == 2 || PlayerPrefs.Equals("Lvl Alcanzado", 2))
        {
            PlayerPrefs.SetInt("Lvl Alcanzado", 3);
        }
    }
    public void MenuLoose()
    {
        SceneManager.LoadScene(0);

        if (SceneManager.GetActiveScene().buildIndex == 1 || PlayerPrefs.Equals("Lvl Alcanzado", 1))
        {
            PlayerPrefs.SetInt("Lvl Alcanzado", 2);
        }

        if (SceneManager.GetActiveScene().buildIndex == 2 || PlayerPrefs.Equals("Lvl Alcanzado", 2))
        {
            PlayerPrefs.SetInt("Lvl Alcanzado", 3);
        }
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
