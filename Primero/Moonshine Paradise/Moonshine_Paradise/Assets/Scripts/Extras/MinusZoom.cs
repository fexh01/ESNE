using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusZoom : MonoBehaviour
{
    public Canvas menu;
    public GameObject camera;
    private Camera view;
    private RectTransform tamañoMenu;
    private float tamMenuX, tamMenuY;
    // Start is called before the first frame update
    void Start()
    {
        view = camera.GetComponent<Camera>();
        tamañoMenu = menu.GetComponent<RectTransform>();
        tamMenuX = tamañoMenu.localScale.x / 4;
        tamMenuY = tamañoMenu.localScale.y / 4;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (view.orthographicSize < 5)
            zoom();
    }

    void zoom()
    {
        if (view.orthographicSize < 5)
        {
            view.orthographicSize += 1.25f;
            tamañoMenu.localScale += new Vector3(tamMenuX, tamMenuY, 0);
        } 
        else
            view.orthographicSize = 5;
        
    }
}
