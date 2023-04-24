using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Level0()
    {
        SceneManager.LoadScene("Level0");
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void ChangeScene(string Name)
    {
        SceneManager.LoadScene(Name);
    }
}
