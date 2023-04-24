using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int speed;
    public Vector3 dir;


    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Roby>() != null)
        {
            other.gameObject.GetComponent<Roby>().Damage();
            Destroy(gameObject);
        }

        else if (other.gameObject.layer == LayerMask.NameToLayer("Paredes"))
        {
            Destroy(gameObject);
        }
    }
}
