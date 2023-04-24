using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanEnemyWayPoint : MonoBehaviour
{
    //[SerializeField]
   public Transform[] waypoints;

    //[SerializeField]
    public float speed;

    int waypointIndex = 0;

    private AudioSource RisaMalvada;

    bool movingRight;
    bool movingLeft;
    bool movingDown;
    bool movingUp;

    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
        RisaMalvada = GetComponent<AudioSource>();
    }

    void Update()
    {
        Move();

        if(movingDown == true)
        {
            GetComponent<Animator>().SetBool("X", false);
            GetComponent<Animator>().SetBool("Y+", false);
            GetComponent<Animator>().SetBool("Y-", true);
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (movingUp == true)
        {
            GetComponent<Animator>().SetBool("X", false);
            GetComponent<Animator>().SetBool("Y+", true);
            GetComponent<Animator>().SetBool("Y-", false);
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (movingLeft == true)
        {
            GetComponent<Animator>().SetBool("X", true);
            GetComponent<Animator>().SetBool("Y+", false);
            GetComponent<Animator>().SetBool("Y-", false);
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (movingRight == true)
        {
            GetComponent<Animator>().SetBool("X", true);
            GetComponent<Animator>().SetBool("Y+", false);
            GetComponent<Animator>().SetBool("Y-", false);
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void Move()
    {
        if (transform.position == waypoints [waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }

        if(waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
            speed += 1.5f;
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);
        
         if(transform.position.x - waypoints[waypointIndex].transform.position.x >= 0.8f)
        {
            movingLeft = true;

            movingUp = false;
            movingRight = false;
            movingDown = false;
        }

        else if (transform.position.x - waypoints[waypointIndex].transform.position.x <= -0.8)
        {
            movingRight = true;

            movingUp = false;
            movingDown = false;
            movingLeft = false;
        }

         if (transform.position.y - waypoints[waypointIndex].transform.position.y >= 0.8)
        {
            movingDown = true;

            movingUp = false;
            movingRight = false;
            movingLeft = false;
        }

        else if (transform.position.y - waypoints[waypointIndex].transform.position.y <= -0.8)
        {
            movingUp = true;

            movingDown = false;
            movingRight = false;
            movingLeft = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Roby>() != null)
        {
            other.gameObject.GetComponent<Roby>().Damage();
            RisaMalvada.Play();
        }
    }
}
