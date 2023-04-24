using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiempoAtaque : MonoBehaviour
{
    Image attackTimer;
    public float complete;
    public float charging;
    public bool attackCharged;


    void Start()
    {
        attackTimer = GetComponent<Image>();
        charging = complete;
        attackCharged = true;
    }

    public void Charging()
    {
        charging = 0;
        attackCharged = false;
    }

    void Update()
    {
        attackTimer.fillAmount = charging / complete;

        if (attackCharged == false && charging < complete)
        {
            charging += Time.deltaTime;
        }

        if(charging >= complete)
        {
            attackCharged = true;
        }
    }
}
