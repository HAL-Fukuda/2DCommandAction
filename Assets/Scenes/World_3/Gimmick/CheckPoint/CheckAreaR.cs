using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAreaR : MonoBehaviour
{
    public bool checkFlagPR = false;  //Playerが触れているか
    public bool checkFlagCR = false;  //Commandが触れているか
    public bool frontFlagR = false;  //左方向に動いているか

    private GameObject moveFloor;  //動く床のオブジェクト
    private MovingFloor movingFloorSc;  //動く床のスクリプト
    private int moveDirection = 0;  //動く床の移動方向

    void Start()
    {
        //動く床のスクリプトを取得
        moveFloor = GameObject.Find("MovingFloor");
        movingFloorSc = moveFloor.GetComponent<MovingFloor>();
    }

    void FixedUpdate()
    {
        MoveDirection();
    }

    private void MoveDirection()
    {
        //移動方向の変数を取得
        moveDirection = movingFloorSc.direction;

        //左方向
        if (moveDirection == -1)
        {
            frontFlagR = true;
        }
        //右方向
        if (moveDirection == 1)
        {
            frontFlagR = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //触れているのがPlayerなら
        if (collision.gameObject.CompareTag("Player"))
        {
            checkFlagPR = true;
        }
        //触れているのがCommandなら
        else if (collision.gameObject.CompareTag("Command"))
        {
            checkFlagCR = true;
        }
    }

    private void OnTriggerExit2D(Collider2D exCollision)
    {
        //離れたのがPlayerなら
        if (exCollision.gameObject.CompareTag("Player"))
        {
            checkFlagPR = false;
        }
        //離れたのがCommandなら
        else if (exCollision.gameObject.CompareTag("Command"))
        {
            checkFlagCR = false;
        }
    }
}
