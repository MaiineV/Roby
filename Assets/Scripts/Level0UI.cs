using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0UI : MonoBehaviour
{

    public GameObject UINeeds;
    public GameObject attack;
    public GameObject map;
    public GameObject lifeDisplay;
    public GameObject bienvenido;
    public GameObject WASD;
    public GameObject insumos;
    public GameObject enemigo;
    public GameObject mapaHelp;
    public GameObject lives;
    public GameObject attackHelp;
    public GameObject endOfTraining;
    public GameObject time;
    public GameObject barra;
    public GameObject engranaje;
    public GameObject charge;
    public GameObject Roby;
    public GameObject enterToSkip;
    private int hurtCount;
    public Canvas ganaste;
    public GameObject arrowHealth;
    public GameObject arrowBarra;
    public GameObject arrowAttack;
    public GameObject arrowMap;
    private int attackCount;
    private int welcomeCount;
    
    

    void Start()
    {
        UINeeds.SetActive(false); attack.SetActive(false); map.SetActive(false); enemigo.SetActive(false); mapaHelp.SetActive(false); lives.SetActive(false); attackHelp.SetActive(false); endOfTraining.SetActive(false); barra.SetActive(false); time.SetActive(false);
        lifeDisplay.GetComponent<LifeDisplay>().enabled = false;
    }


    void Update()
    {
        if (attack.active == false)
        {
            charge.GetComponent<TiempoAtaque>().attackCharged = false;
        }

        /*___________________________________________________________________BIENVENIDO SIGN_______________________________________________*/
        if (bienvenido.active || WASD.active || insumos.active)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                welcomeCount++;
            }
        }

        switch (welcomeCount)
        {
            case 0:
                bienvenido.SetActive(true);
                WASD.SetActive(false);
                insumos.SetActive(false);
                break;

            case 1:
                WASD.SetActive(true);
                bienvenido.SetActive(false);
                break;

            case 2:
                insumos.SetActive(true);
                WASD.SetActive(false);
                break;

            case 3:
                insumos.SetActive(false);
                break;
        }

        /*___________________________________________________________________COLLECTIBLES SIGN_______________________________________________*/

        if (barra.active)
        {
            arrowBarra.GetComponent<Animator>().SetTrigger("SetArrow");
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                barra.SetActive(false);
                arrowBarra.GetComponent<Animator>().SetTrigger("next");
            }
        }

        /*___________________________________________________________________MAPA SIGN_______________________________________________*/

        if (mapaHelp.active)
        {
            arrowMap.GetComponent<Animator>().SetTrigger("SetArrow");
            map.SetActive(true);
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                mapaHelp.SetActive(false);
                arrowMap.GetComponent<Animator>().SetTrigger("next");
            }
        }

        /*___________________________________________________________________ENEMY SIGN_______________________________________________*/

        if (enemigo.active)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                enemigo.SetActive(false);
            }
        }

        /*___________________________________________________________________LIVES SIGN_______________________________________________*/

        if (Roby.GetComponent<Roby>().hp < 3)
        {
            lifeDisplay.GetComponent<LifeDisplay>().enabled = true;
            lives.SetActive(true);
            arrowHealth.GetComponent<Animator>().SetTrigger("SetArrow");
            if (lives.active)
            {
                if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    arrowHealth.GetComponent<Animator>().SetTrigger("next");
                    hurtCount = 1;
                }
            }
        }

        if (hurtCount == 1)
        {
            lives.SetActive(false);
        }

        /*___________________________________________________________________ATTACK SIGNS_______________________________________________*/

        if (attackHelp.active)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                attackHelp.GetComponent<Animator>().SetTrigger("next");
                attack.SetActive(true);
                arrowAttack.GetComponent<Animator>().SetTrigger("next");
                arrowAttack.GetComponent<Animator>().SetTrigger("SetArrow");
                attackCount++;
            }
        }
        if(attackCount >= 3)
        {
            attackHelp.active = false;
        }

        /*___________________________________________________________________FREEZE/PLAY ROBY_______________________________________________*/

        if (enemigo.active || mapaHelp.active || lives.active || attackHelp.active || endOfTraining.active || barra.active || bienvenido.active || WASD.active || insumos.active || time.active)
        {
            Roby.GetComponent<Roby>().speed = 0;
        }

        else if (enemigo.active == false && mapaHelp.active == false && lives.active == false && attackHelp.active == false && endOfTraining.active == false && barra.active == false && bienvenido.active == false && WASD.active == false && insumos.active == false && time.active == false)
        {
            Roby.GetComponent<Roby>().speed = 9;
        }
    }
}

