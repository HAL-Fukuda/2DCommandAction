using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class MovingFloorChecker : MonoBehaviour
{
    public bool frontFlagR = false;  //左方向に動いているか

    private GameObject moveFloor;  //動く床のオブジェクト
    private MovingFloor movingFloorSc;  //動く床のスクリプト
    private int moveDirection = 0;  //動く床の移動方向
    private Vector3 moveVal;  //動く床の移動量

    private List<Collider2D> colliders = new List<Collider2D>(); // 床の上に乗っているオブジェクトのリスト

    void Start()
    {
        //動く床のスクリプトを取得
        moveFloor = GameObject.Find("MovingFloor");
        movingFloorSc = moveFloor.GetComponent<MovingFloor>();
    }

    void FixedUpdate()
    {
        MoveDirection();

        moveVal = movingFloorSc.moveVal;

        // 床の上に乗っているオブジェクトを移動させる
        foreach (Collider2D collider in colliders)
        {
            if (collider != null && collider.gameObject != null)
            {
                collider.gameObject.transform.position += moveVal;
            }
        }
    }

    private void MoveDirection()
    {
        //移動方向の変数を取得
        moveDirection = movingFloorSc.direction;

        //左方向
        if (moveDirection == -1)
        {
            frontFlagR = false;
        }
        //右方向
        if (moveDirection == 1)
        {
            frontFlagR = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 床の上にオブジェクトが乗ったときにリストに追加する
        if (other.gameObject.CompareTag("Player"))
        {
            colliders.Add(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // 床からオブジェクトが離れたときにリストから削除する
        if (other.gameObject.CompareTag("Player"))
        {
            colliders.Remove(other);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 床の上にオブジェクトが乗ったときにリストに追加する
        if (collision.gameObject.CompareTag("Command"))
        {
            colliders.Add(collision.collider);
            //ShowListContentsInTheDebugLog(colliders);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // 床からオブジェクトが離れたときにリストから削除する
        if (collision.gameObject.CompareTag("Command"))
        {
            colliders.Remove(collision.collider);
        }
    }

    public void ShowListContentsInTheDebugLog<T>(List<T> list)
    {
        string log = "";

        foreach (var content in list.Select((val, idx) => new { val, idx }))
        {
            if (content.idx == list.Count - 1)
                log += content.val.ToString();
            else
                log += content.val.ToString() + ", ";
        }

        //Debug.Log(log);
    }
}
