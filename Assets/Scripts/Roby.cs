using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Roby : MonoBehaviour
{
    Animator _animator;
    public int speed;
    public int hp;
    public Rigidbody2D rb;
    public Canvas pausaCanvas;
    public Canvas perdisteCanvas;
    public Canvas mapaCanvas;
    private AudioSource Pain;
    public GameObject cursor;
    public Vector2 cursorPos;
    public GameObject coheteCharging;
    public GameObject projectile;
    private Vector2 spawnAbove;

    enum State
    {
        forward,
        backward,
        rigth,
        left
    }

    State _actualState = State.forward;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool(_actualState.ToString(), true);

        hp = 3;
        Pain = GetComponent<AudioSource>();
    }

    void Update()
    {

        cursorPos = cursor.transform.position;

        /*___________________________________________________________________MOVIMIENTO_______________________________________________*/

        Vector2 dir;

        dir.x = Input.GetAxis("Horizontal");
        dir.y = Input.GetAxis("Vertical");

        dir.Normalize();
        rb.velocity = dir * speed;

        /*___________________________________________________________________LIMITES_______________________________________________*/


        //if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level1"))
        //{
        //    transform.position = new Vector2(Mathf.Clamp(transform.position.x, -18.52f, 31.66f), Mathf.Clamp(transform.position.y, -12.23f, 37.4f));
        //}

        //else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level2"))
        //{
        //    transform.position = new Vector2(Mathf.Clamp(transform.position.x, -32.87f, 21f),Mathf.Clamp(transform.position.y, -14.344f, 40.8f));
        //}

        //else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level0"))
        //{
        //    transform.position = new Vector2(Mathf.Clamp(transform.position.x, -49.8f, -1.2f), Mathf.Clamp(transform.position.y, -22.17f, 31.3f));
        //}


        /*___________________________________________________________________ANIMACIONES_______________________________________________*/

        if (Input.GetKeyDown(KeyCode.W))
        {
           _animator.SetBool(_actualState.ToString(), false);
            _actualState = State.backward;
           _animator.SetBool(_actualState.ToString(), true);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _animator.SetBool(_actualState.ToString(), false);
            _actualState = State.left;
            _animator.SetBool(_actualState.ToString(), true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _animator.SetBool(_actualState.ToString(), false);
            _actualState = State.forward;
            _animator.SetBool(_actualState.ToString(), true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _animator.SetBool(_actualState.ToString(), false);
            _actualState = State.rigth;
            _animator.SetBool(_actualState.ToString(), true);
        }

        if (coheteCharging.GetComponent<TiempoAtaque>().attackCharged == true && mapaCanvas.enabled == false && pausaCanvas.enabled == false)
        {
            if (Input.GetKeyDown(KeyCode.E) /*&& cursorPos.y >= -4.82*/)
            {
                    Attack();
            }
        }
    }

    /*___________________________________________________________________ATAQUE_______________________________________________*/

    void Attack()
    {
        print("Attack");
        GetComponent<Animator>().SetTrigger("Attack");
        GetComponent<Animator>().ResetTrigger("Hurt");
        GetComponent<Animator>().SetBool("Walk", false);
        coheteCharging.GetComponent<TiempoAtaque>().Charging();

        
        spawnAbove.y = cursorPos.y + 22;
        spawnAbove.x = cursorPos.x;

        GameObject newProjectile = Instantiate(projectile, spawnAbove, transform.rotation);

        if(newProjectile.transform.position.y == spawnAbove.y-20)
        {
            newProjectile.isStatic = true;
            newProjectile.GetComponent<Animator>().SetTrigger("collided");
        }
    }

    /*___________________________________________________________________DAMAGE_______________________________________________*/
    public void Damage()
    {
        print("Auch");
        hp--;
        GetComponent<Animator>().SetTrigger("Hurt");
        GetComponent<Animator>().ResetTrigger("Attack");
        GetComponent<Animator>().SetBool("Walk", false);
        Pain.Play();

        if (hp <= 0)
        {
            Death();
        }
    }

    /*___________________________________________________________________DEATH_______________________________________________*/
    public void Death()
    {
        GetComponent<Animator>().SetTrigger("Death");
        GetComponent<Animator>().ResetTrigger("Attack");
        GetComponent<Animator>().ResetTrigger("Hurt");
        GetComponent<Animator>().SetBool("Walk", false);
        speed = 0;
    }

    /*___________________________________________________________________PERDISTE____________________________________________*/
    public void Perdiste()
    {
        perdisteCanvas.gameObject.GetComponent<Perdiste>().Dead();
    }
}