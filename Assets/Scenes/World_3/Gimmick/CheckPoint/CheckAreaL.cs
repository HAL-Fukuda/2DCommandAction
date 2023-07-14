using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAreaL : MonoBehaviour
{
    public bool checkFlagPL = false;  //Playerが触れているか
    public bool checkFlagCL = false;  //Commandが触れているか
    public bool frontFlagL = false;  //左方向に動いているか

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
            frontFlagL = true;
        }
        //右方向
        if (moveDirection == 1)
        {
            frontFlagL = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //触れているのがPlayerなら
        if (collision.gameObject.CompareTag("Player"))
        {
            checkFlagPL = true;
        }
        //触れているのがCommandなら
        else if (collision.gameObject.CompareTag("Command"))
        {
            checkFlagCL = true;
        }
    }

    private void OnTriggerExit2D(Collider2D exCollision)
    {
        //離れたのがPlayerなら
        if (exCollision.gameObject.CompareTag("Player"))
        {
            checkFlagPL = false;
        }
        //離れたのがCommandなら
        else if (exCollision.gameObject.CompareTag("Command"))
        {
            checkFlagCL = false;
        }
    }
}
