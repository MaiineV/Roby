using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public bool Ray;
    public bool Vertical;
    public GameObject bulletPrefab;
    public Transform whereToSpawn;

    void Awake()
    {
        if (Ray == true)
        {
            GetComponent<Animator>().SetBool("bullets", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("bullets", true);
        }

        if (Vertical == true)
        {
            GetComponent<Animator>().SetBool("horizontal", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("horizontal", true);
        }
    }

    void Shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, whereToSpawn.position, whereToSpawn.rotation);
        
        if (Vertical == true)
        {
            newBullet.GetComponent<Bullets>().dir = Vector3.down;
        }
        else
        {
            newBullet.GetComponent<Bullets>().dir = Vector3.left;
        }
    }
}
