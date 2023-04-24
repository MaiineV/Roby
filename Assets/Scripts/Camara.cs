using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform target;
    public Transform Roby;
    public Transform enemy;
    public Vector3 offset;
    public bool stopTime;


    void Start()
    {
        stopTime = false;
        target = Roby;
    }


    void Update()
    {
        if (stopTime == true)
        {
            Time.timeScale = 0;
        }
        else if (stopTime == false)
        {
            Time.timeScale = 1;
        }

        /*___________________________________________________________________SIGUE A TARGET_______________________________________________*/

        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, 0.1f);
        }

        /*___________________________________________________________________LIMITES_______________________________________________*/

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level1"))
        {
            transform.position = new Vector3(Mathf.Clamp(target.position.x, -6.06f, 19.26f), Mathf.Clamp(target.position.y, -6.02f, 31.46f), transform.position.z);
        }

        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level2"))
        {
            transform.position = new Vector3(Mathf.Clamp(target.position.x, -21.24f, 9.2f), Mathf.Clamp(target.position.y, -8.27f, 35.1f), transform.position.z);
        }

        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level0"))
        {
            transform.position = new Vector3(Mathf.Clamp(target.position.x, -39.3f, -9.3f), Mathf.Clamp(target.position.y, -16.99f, 25.7f), transform.position.z);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position - offset, .25f);
    }

    public void ShowingEnemy()
    {
        target = enemy;
    }

}
