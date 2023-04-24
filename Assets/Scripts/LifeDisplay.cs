using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeDisplay : MonoBehaviour
{

    public GameObject LifePreFab;
    public List<GameObject> heartList;
    public Vector3 offset;
    public Roby Roby;
    public Vector3 firstHeartPos;




    void Awake()
    {
        for (int i = 0; i < Roby.hp; i++)
        {
            heartList.Add(Instantiate(LifePreFab));
            heartList[i].transform.SetParent(this.transform);
        }
    }

    /*___________________________________________________________________POSICION_______________________________________________*/
    void Update()
    {
        for (int i = 0; i < heartList.Count; i++)
        {
            heartList[i].transform.position = transform.position + firstHeartPos + offset * i;
        }

        /*___________________________________________________________________-HP_______________________________________________*/
        while (heartList.Count > Roby.hp)
        {
            heartList[heartList.Count - 1].GetComponent<Animator>().SetTrigger("-hp");
            Destroy(heartList[heartList.Count - 1], 5f);
            heartList.RemoveAt(heartList.Count - 1);
        }

    }

}

