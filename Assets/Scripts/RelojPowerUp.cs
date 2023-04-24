using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelojPowerUp : MonoBehaviour
{
    private AudioSource alarmOff;
    SpriteRenderer rend;
    public GameObject time;

    void Start()
    {
        alarmOff = GetComponent<AudioSource>();
        rend = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Roby>() != null)
        {
            StartCoroutine("FadeOut");
            GetComponent<CircleCollider2D>().enabled = false;
            alarmOff.Play();
            time.GetComponent<Timelimit>().timeLeft += 15;
        }
    }

    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.005f);
        }
    }
}
