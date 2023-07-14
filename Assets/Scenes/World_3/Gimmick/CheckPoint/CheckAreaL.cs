using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAreaL : MonoBehaviour
{
    public bool checkFlagPL = false;  //Player���G��Ă��邩
    public bool checkFlagCL = false;  //Command���G��Ă��邩
    public bool frontFlagL = false;  //�������ɓ����Ă��邩

    private GameObject moveFloor;  //�������̃I�u�W�F�N�g
    private MovingFloor movingFloorSc;  //�������̃X�N���v�g
    private int moveDirection = 0;  //�������̈ړ�����

    void Start()
    {
        //�������̃X�N���v�g���擾
        moveFloor = GameObject.Find("MovingFloor");
        movingFloorSc = moveFloor.GetComponent<MovingFloor>();
    }

    void FixedUpdate()
    {
        MoveDirection();
    }

    private void MoveDirection()
    {
        //�ړ������̕ϐ����擾
        moveDirection = movingFloorSc.direction;

        //������
        if (moveDirection == -1)
        {
            frontFlagL = true;
        }
        //�E����
        if (moveDirection == 1)
        {
            frontFlagL = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�G��Ă���̂�Player�Ȃ�
        if (collision.gameObject.CompareTag("Player"))
        {
            checkFlagPL = true;
        }
        //�G��Ă���̂�Command�Ȃ�
        else if (collision.gameObject.CompareTag("Command"))
        {
            checkFlagCL = true;
        }
    }

    private void OnTriggerExit2D(Collider2D exCollision)
    {
        //���ꂽ�̂�Player�Ȃ�
        if (exCollision.gameObject.CompareTag("Player"))
        {
            checkFlagPL = false;
        }
        //���ꂽ�̂�Command�Ȃ�
        else if (exCollision.gameObject.CompareTag("Command"))
        {
            checkFlagCL = false;
        }
    }
}
