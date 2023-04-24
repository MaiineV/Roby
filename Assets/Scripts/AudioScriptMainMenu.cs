using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioScriptMainMenu : MonoBehaviour
{
    private static AudioScriptMainMenu instance;

    void Awake()
    {
            if (instance != null)
            {
               Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(transform.gameObject);
            }
        
    }
    void Update()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Creditos") && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("MainMenu"))
        {
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(transform.gameObject);
        }
    }
}