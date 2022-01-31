using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public Receptor receptor;
    public bool active;
    public GameObject menu;
    public GameObject end;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            
        }
    }

    public void ToGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        menu.SetActive(false);
        
    }

    public void ToMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        end.SetActive(false);
        menu.SetActive(true);
    }

    public void ToEnd()
    {
        if (receptor.active)
        {
            active = true;
        }
        
    }
}
