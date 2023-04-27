using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Switch : MonoBehaviour
{
    public float movedistance = 1.0f;
    public float moveDuration = 1f; // 移動にかかる時間
    private Transform elevator; // 動くオブジェクト
    private Transform conveyor;

    void Start()
    {
        elevator = GameObject.FindWithTag("elevator").transform;
        conveyor = GameObject.FindWithTag("conveyor").transform;
    }
}
