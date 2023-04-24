using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    private Canvas PauseMenu;
    public Camera MainCamera;
    public Canvas Perdiste, Ganaste, mapCanvas;
    

    void Start()
    {
        PauseMenu = GetComponent<Canvas>();
        PauseMenu.enabled = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Perdiste.enabled == false && Ganaste.enabled == false && mapCanvas.enabled == false)
        {
            DisableMenu();
        }

   
        if (PauseMenu.enabled == true)
        {
            MainCamera.GetComponent<Camara>().stopTime = true;
        }
        
    }

    public void DisableMenu()
    {
        if (PauseMenu.enabled == false)
        {
            PauseMenu.enabled = true;
        }
        else
        {
            PauseMenu.enabled = false;
            MainCamera.GetComponent<Camara>().stopTime = false;
        }
    }
}
