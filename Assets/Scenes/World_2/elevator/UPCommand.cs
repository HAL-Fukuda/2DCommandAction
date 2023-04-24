using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class Command : MonoBehaviour
{
    public float movedistance = 1.0f;
    public float moveDuration = 1f; // 移動にかかる時間
    private Transform elevator; // 動くオブジェクト

    public void UpInitialize()
    {
        // シーン内の"elevator"オブジェクトを検索する
        elevator = GameObject.Find("elevator").transform;
    }

    public void UpUpdate()
    {
        UpInitialize();
        elevator.DOMoveY(elevator.position.y + movedistance, moveDuration);
    }
}
