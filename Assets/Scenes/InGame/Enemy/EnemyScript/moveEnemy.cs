using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Enemy : MonoBehaviour
{
    public float WindowOutposition;

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