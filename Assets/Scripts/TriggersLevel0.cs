using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersLevel0 : MonoBehaviour
{
    public GameObject sign;
    public int count;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Roby>() != null && count <1)
        {
            sign.SetActive(true);
        }
    }

    private void Update()
    {
        if(sign.active)
        {
            count++;
        }
    }
}
