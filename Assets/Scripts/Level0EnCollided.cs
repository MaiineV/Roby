using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0EnCollided : MonoBehaviour
{
    public GameObject barra;
    public GameObject UINeeds;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Roby>() != null)
        {
            barra.SetActive(true); UINeeds.SetActive(true);
        }
    }
}
