using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowingEnemy : MonoBehaviour
{
    public GameObject Escuchaste;
    public GameObject TeneCuidado;
    public GameObject skip;
    public GameObject camara;
    public int count;
    public GameObject Roby;

    void Start()
    {
        TeneCuidado.SetActive(false);
        Escuchaste.SetActive(true);
        skip.SetActive(true);
        count = 0;
        Roby.GetComponent<Roby>().speed = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return))
        {
            count++;
        }

        switch (count)
        {
            case 0:
                Escuchaste.SetActive(true);
                break;

            case 1:
                camara.GetComponent<Camara>().ShowingEnemy();
                TeneCuidado.SetActive(true);
                Escuchaste.SetActive(false);
                break;

            case 2:
                TeneCuidado.SetActive(false);
                skip.SetActive(false);
                camara.GetComponent<Camara>().target = camara.GetComponent<Camara>().Roby;
                Roby.GetComponent<Roby>().speed = 9;
                break;
        }


        
        }
}
