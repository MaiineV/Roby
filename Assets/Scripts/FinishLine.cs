using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject UIEn, UIDes, UILlav, UIMar, UIPin, UITuer;
    public Canvas ganasteCanvas;
    public Camera MainCamera;
    public GameObject candadito;
    public GameObject endOfTraining;
    public GameObject time;
    private int byeCount = 0;


    public void OnTriggerEnter2D(Collider2D other)
    {
        /*___________________________________________________________________LLEGADA LEVELS_______________________________________________*/

        if (other.gameObject.GetComponent<Roby>() != null && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Level0"))
        {
            if (UIEn.GetComponent<Collectibles>().grabbed == true &&
              UIDes.GetComponent<Collectibles>().grabbed == true &&
              UILlav.GetComponent<Collectibles>().grabbed == true &&
              UIMar.GetComponent<Collectibles>().grabbed == true &&
              UIPin.GetComponent<Collectibles>().grabbed == true &&
              UITuer.GetComponent<Collectibles>().grabbed == true)
            {
                MainCamera.GetComponent<Camara>().stopTime = true;
                ganasteCanvas.enabled = true;
                print("llegamos");
            }
        }

        /*___________________________________________________________________LLEGADA LEVEL0_______________________________________________*/

        else if (other.gameObject.GetComponent<Roby>() != null && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level0"))
        {
            if (UIEn.GetComponent<Collectibles>().grabbed == true &&
              UIDes.GetComponent<Collectibles>().grabbed == true &&
              UILlav.GetComponent<Collectibles>().grabbed == true &&
              UIMar.GetComponent<Collectibles>().grabbed == true &&
              UIPin.GetComponent<Collectibles>().grabbed == true &&
              UITuer.GetComponent<Collectibles>().grabbed == true)
            {
                byeCount = 1;
                
            }
        }

        /*___________________________________________________________________LLEGADA SIN COLECTIBLES_______________________________________________*/

        if (other.gameObject.GetComponent<Roby>() != null)
        {
            if (UIEn.GetComponent<Collectibles>().grabbed != true ||
              UIDes.GetComponent<Collectibles>().grabbed != true ||
              UILlav.GetComponent<Collectibles>().grabbed != true ||
              UIMar.GetComponent<Collectibles>().grabbed != true ||
              UIPin.GetComponent<Collectibles>().grabbed != true ||
              UITuer.GetComponent<Collectibles>().grabbed != true)
            {
                candadito.GetComponent<SpriteRenderer>().enabled = true;
                candadito.GetComponent<Animator>().SetTrigger("Reaparece");
            }
        }
    }


    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level0"))
        {
            switch (byeCount)
            {
                case 1:
                    endOfTraining.SetActive(true);
                    break;

                case 2:
                    time.SetActive(true);
                    endOfTraining.SetActive(false);
                    break;

                case 3:
                    time.SetActive(false);
                    MainCamera.GetComponent<Camara>().stopTime = true;
                    ganasteCanvas.enabled = true;
                    break;

            }
        }

        if(byeCount >= 1)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                byeCount++;
            }
        }
    }
}
