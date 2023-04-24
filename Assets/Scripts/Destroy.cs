using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float TimeTillDestroy;

    void Update()
    {
        Destroy(gameObject, TimeTillDestroy);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Roby>() != null)
        {
            other.gameObject.GetComponent<Roby>().Damage();
            Destroy(gameObject);
        }
    }
    }
