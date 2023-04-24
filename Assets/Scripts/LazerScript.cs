using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScript : MonoBehaviour
{
    private float timeTilSpawn;
    public float startTimeTilSpawn;
    public GameObject lazerColl;
    public GameObject lazerStart;
    public GameObject lazerMiddle;



    void Update()
    {
        if (timeTilSpawn <= 0)
        {
            lazerColl.GetComponent<Animator>().SetTrigger("Instantiate");
            lazerMiddle.GetComponent<Animator>().SetTrigger("Instantiate");
            lazerStart.GetComponent<Animator>().SetTrigger("Instantiate");
            timeTilSpawn = startTimeTilSpawn;
        }

        else
        {
            timeTilSpawn -= Time.deltaTime;
            lazerStart.GetComponent<Animator>().ResetTrigger("Instantiate");
            lazerColl.GetComponent<Animator>().ResetTrigger("Instantiate");
            lazerMiddle.GetComponent<Animator>().ResetTrigger("Instantiate");
        }
    }
}
