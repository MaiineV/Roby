using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ganaste : MonoBehaviour
{
    private Canvas ganasteCanvas;
    public Camera MainCamera;

    void Start()
    {
        ganasteCanvas = GetComponent<Canvas>();
        ganasteCanvas.enabled = false;
    }
}
    
