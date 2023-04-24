using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapaScript : MonoBehaviour
{
    public Canvas mapCanvas;
    public GameObject Roby;
    public Camera MainCamera;
    public Vector2 CameraPos;
    public GameObject cursor;
    public Vector2 cursorPos;

    void Start()
    {
        mapCanvas = GetComponent<Canvas>();
        mapCanvas.enabled = false;
    }


    void Update()
    {
        cursorPos = cursor.transform.position;
        CameraPos = MainCamera.transform.position;

        if (mapCanvas.enabled == true)
        {
            MainCamera.GetComponent<Camara>().stopTime = true;

            if (Input.GetMouseButtonDown(0))
            {
                if ((CameraPos.x + 6.95f) <= cursorPos.x || cursorPos.x <= (CameraPos.x - 7.12f))
                {
                    MainCamera.GetComponent<Camara>().stopTime = false;
                    mapCanvas.enabled = false;
                }
            }

            else if (Input.GetKeyDown(KeyCode.Tab))
            {
                MainCamera.GetComponent<Camara>().stopTime = false;
                mapCanvas.enabled = false;
            }
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                mapCanvas.enabled = true;
            }
        }
    }
}
