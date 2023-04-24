using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Roby : MonoBehaviour
{

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


    void Start()
    {

        GetComponent<Animator>().SetBool("F", true);
        hp = 3;
        Pain = GetComponent<AudioSource>();
    }

    void Update()
    {

        cursorPos = cursor.transform.position;

        /*___________________________________________________________________MOVIMIENTO_______________________________________________*/

        Vector2 dir;

        dir.x = Input.GetAxis("Horizontal") * speed;
        dir.y = Input.GetAxis("Vertical") * speed;
        rb.velocity = dir;

        /*___________________________________________________________________LIMITES_______________________________________________*/


        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level1"))
        {
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -18.52f, 31.66f), Mathf.Clamp(transform.position.y, -12.23f, 37.4f));
        }

        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level2"))
        {
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -32.87f, 21f),Mathf.Clamp(transform.position.y, -14.344f, 40.8f));
        }

        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level0"))
        {
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -49.8f, -1.2f), Mathf.Clamp(transform.position.y, -22.17f, 31.3f));
        }


        /*___________________________________________________________________ANIMACIONES_______________________________________________*/

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A))
        {
            GetComponent<Animator>().SetBool("Walk", true);
        }

        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A))
        {
            GetComponent<Animator>().SetBool("Walk", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("X+", true);
            GetComponent<Animator>().SetBool("X-", false);
        }


        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Animator>().SetBool("X-", true);
            GetComponent<Animator>().SetBool("X+", false);
        }


        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Animator>().SetBool("E", true);
            GetComponent<Animator>().SetBool("F", false);
            GetComponent<Animator>().SetBool("X+", false);
            GetComponent<Animator>().SetBool("X-", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Animator>().SetBool("F", true);
            GetComponent<Animator>().SetBool("E", false);
            GetComponent<Animator>().SetBool("X+", false);
            GetComponent<Animator>().SetBool("X-", false);
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