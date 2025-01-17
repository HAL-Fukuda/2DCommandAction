using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class elevator : MonoBehaviour
{
    public float movedistance = 2.0f;
    public float moveDuration = 2.0f; // 移動にかかる時間

    public bool UpTrigger = false;
    public bool DownTrigger = false;

    private bool isMovingUp = true; // 現在上昇中かどうか
    public float interval = 2.0f; // 上昇と下降の切り替え時間間隔

    public bool isPaused = false;

    void Start()
    {
        // interval秒ごとにChangeDirectionメソッドを繰り返し呼び出す
        InvokeRepeating("ChangeDirection", interval, interval);
    }

    void ChangeDirection()
    {
        if (!isPaused)
        {
            isMovingUp = !isMovingUp;
            if (isMovingUp)
            {
                UpTrigger = true;
            }
            if (!isMovingUp)
            {
                DownTrigger = true;
            }
        }
    }

    void Update()
    {
        if (UpTrigger)
        {
            UpUpdate();
        }
        if (DownTrigger)
        {
            DownUpdate();
        }
    }

    public void UpUpdate()
    {
        transform.DOMoveY(transform.position.y + movedistance, moveDuration);
        UpTrigger = false;
    }

    public void DownUpdate()
    {
        transform.DOMoveY(transform.position.y - movedistance, moveDuration);
        DownTrigger = false;
    }
}
