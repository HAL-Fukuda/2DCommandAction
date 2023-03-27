using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemy : MonoBehaviour
{
    public float WindowOutposition;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            WindowIn();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            WindowOut();
        }
    }

    public void WindowIn()
    {
        transform.position = new Vector3(0, 4, 0);
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void WindowOut()
    {
        transform.position = new Vector3(0, WindowOutposition, 0);
        transform.localScale = new Vector3(2, 2, 1);
    }
}