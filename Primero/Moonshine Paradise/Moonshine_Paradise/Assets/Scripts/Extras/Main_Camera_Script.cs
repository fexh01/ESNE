using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera_Script : MonoBehaviour
{
    public bool maintainWidth = true;

    private int current_w = 0;
    private int current_h = 0;

    private float w_amount = 8.325f; //Minimum units horizontally
    private float h_amount = 4.7f; //Minimum units vertically

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        SetRes();
    }

    private void SetRes()
    {
        current_w = Screen.width;
        current_h = Screen.height;
        float width_size = (float)(w_amount * Screen.height / Screen.width * 0.5);
        float height_size = (float)(h_amount * Screen.width / Screen.height * 0.5) * ((float)Screen.height / Screen.width);
        cam.orthographicSize = Mathf.Max(height_size, width_size);
    }

    void Update()
    {
        if (Screen.width != current_w || Screen.height != current_h)
        {
            SetRes();
        }
    }

    // Update is called once per frame

}
