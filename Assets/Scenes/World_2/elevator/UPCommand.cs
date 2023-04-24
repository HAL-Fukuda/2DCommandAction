using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UPCommand : MonoBehaviour
{
    public float movedistance = 1.0f;
    public float moveDuration = 1f; // 移動にかかる時間

    private bool touched = false; // オブジェクトに触れたかどうか
    private Transform elevator; // 動くオブジェクト

    void Start()
    {
        // シーン内の"elevator"オブジェクトを検索する
        elevator = GameObject.Find("elevator").transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            touched = true;
        }
    }

    void Update()
    {
        if (touched)
        {
            elevator.DOMoveY(elevator.position.y + movedistance, moveDuration);
            touched = false; // 1回だけ移動するようにフラグをオフにする
        }
    }
}
