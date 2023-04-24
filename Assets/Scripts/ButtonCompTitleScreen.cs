using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonCompTitleScreen : MonoBehaviour
{
    public Sprite buttonNorm;
    public Sprite buttonSelected;
    public bool New;
    public bool Exit;
    public bool Options;
    private AudioSource selected;
    public SpriteRenderer rend;

   void Start()
    {
        selected = GetComponent<AudioSource>();
        rend.enabled = true;
    }


    void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().sprite = buttonSelected;
    }


    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = buttonNorm;
    }

    void OnMouseDown()
    {
            if (rend.enabled == true)
            {
                selected.Play();
            }
       

        if (New == true)
        {
            GoLevel0();
        }

        if (Exit == true)
        {
            ExitGame();
        }
    }

    public void GoLevel0()
    {
        SceneManager.LoadScene("Level0");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
