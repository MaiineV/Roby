using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perdiste : MonoBehaviour
{
    public GameObject Roby;
    public Canvas perdisteCanvas;
    public Camera MainCamera;
    private AudioSource perdisteAudio;


    void Start()
    {
        perdisteCanvas = GetComponent<Canvas>();
        perdisteCanvas.enabled = false;
        perdisteAudio = GetComponent<AudioSource>();

    }

    public void Dead()
    {
        if(Roby.GetComponent<Roby>().hp <= 0)
        {
            MainCamera.GetComponent<Camara>().stopTime = true;
            perdisteCanvas.enabled = true;
            perdisteAudio.Play();
        }
    }

}
