using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
   
    public bool grabbed;
    public GameObject UI;
    SpriteRenderer rend;
    private AudioSource collect;


    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        collect = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Roby>() != null)
        {
            StartCoroutine("FadeOut");
            grabbed = true;
            GetComponent<BoxCollider2D>().enabled = false;
            collect.Play();
        }
    }

    void Update()
    {
        if(grabbed == false)
        {
            UI.GetComponent<SpriteRenderer>().material.color = new Color(0.4f, 0.4f, 0.4f, 1);
        }
        else
        {
            UI.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 1);
        }
    }

    IEnumerator FadeOut()
    {
        for(float f = 1f; f>= -0.05f; f -=0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.005f);
        }
    }
}
