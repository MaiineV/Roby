using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderLazer : MonoBehaviour
{
    
    public void ActivateCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DeactivateCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Roby>() != null)
        {
            other.gameObject.GetComponent<Roby>().Damage();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

    }
}
