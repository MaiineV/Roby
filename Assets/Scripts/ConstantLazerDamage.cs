using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantLazerDamage : MonoBehaviour
{
    public bool oneTimeDamage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Roby>() != null && oneTimeDamage == true)
        {
            other.gameObject.GetComponent<Roby>().Damage();
            Destroy(gameObject);
        }

        else if (other.gameObject.GetComponent<Roby>() != null && oneTimeDamage == false)
        {
            other.gameObject.GetComponent<Roby>().Damage();
        }

    }
}
