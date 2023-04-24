using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Vector2 spawnPos;
    public Rigidbody2D rb;
    public float destroyRadius;
    private AudioSource explosion;

    void Start()
    {
        spawnPos = transform.position;
        explosion = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(transform.position.y <= spawnPos.y-22)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<Animator>().SetTrigger("collided");
            Collider2D[] allColliders = Physics2D.OverlapCircleAll(transform.position, destroyRadius);
            for(int i =0; i<allColliders.Length; i++)
            {
                if(allColliders[i].gameObject.layer == LayerMask.NameToLayer("Paredes") || allColliders[i].gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    Destroy(allColliders[i].gameObject);
                    print("CHAU");
                    explosion.Play();
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, destroyRadius);
    }
}
