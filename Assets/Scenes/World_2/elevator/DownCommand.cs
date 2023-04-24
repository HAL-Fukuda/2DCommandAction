using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class Command : MonoBehaviour
{
    public void DownInitialize()
    {
        // シーン内の"elevator"オブジェクトを検索する
        elevator = GameObject.Find("elevator").transform;
    }

    public void DownUpdate()
    {
        DownInitialize();
        elevator.DOMoveY(elevator.position.y - movedistance, moveDuration);
    }
}
