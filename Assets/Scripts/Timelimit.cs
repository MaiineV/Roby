using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timelimit : MonoBehaviour
{
    Image timerBar;
    public float maxTime = 5f;
    public float timeLeft;
    public Canvas perdisteCanvas;
    public Camera MainCamera;

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    void Update()
    {
        if(timeLeft > 100)
        {
            timeLeft = 100;
        }

        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        }
        else
        {
            perdisteCanvas.enabled = true;
            MainCamera.GetComponent<Camara>().stopTime = true;
        }
    }
}

