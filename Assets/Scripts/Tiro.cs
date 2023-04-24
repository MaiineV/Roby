using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 CursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = CursorPos;

        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Animator>().SetBool("Pressed", true);
        }

        else if (Input.GetMouseButtonUp(0))
        {
            GetComponent<Animator>().SetBool("Pressed", false);
        }
    }
}
