using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class MovingFloorChecker : MonoBehaviour
{
    public bool frontFlagR = false;  //�������ɓ����Ă��邩

    private GameObject moveFloor;  //�������̃I�u�W�F�N�g
    private MovingFloor movingFloorSc;  //�������̃X�N���v�g
    private int moveDirection = 0;  //�������̈ړ�����
    private Vector3 moveVal;  //�������̈ړ���

    private List<Collider2D> colliders = new List<Collider2D>(); // ���̏�ɏ���Ă���I�u�W�F�N�g�̃��X�g

    void Start()
    {
        //�������̃X�N���v�g���擾
        moveFloor = GameObject.Find("MovingFloor");
        movingFloorSc = moveFloor.GetComponent<MovingFloor>();
    }

    void FixedUpdate()
    {
        MoveDirection();

        moveVal = movingFloorSc.moveVal;

        // ���̏�ɏ���Ă���I�u�W�F�N�g���ړ�������
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
        //�ړ������̕ϐ����擾
        moveDirection = movingFloorSc.direction;

        //������
        if (moveDirection == -1)
        {
            frontFlagR = false;
        }
        //�E����
        if (moveDirection == 1)
        {
            frontFlagR = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ���̏�ɃI�u�W�F�N�g��������Ƃ��Ƀ��X�g�ɒǉ�����
        if (other.gameObject.CompareTag("Player"))
        {
            colliders.Add(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // ������I�u�W�F�N�g�����ꂽ�Ƃ��Ƀ��X�g����폜����
        if (other.gameObject.CompareTag("Player"))
        {
            colliders.Remove(other);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���̏�ɃI�u�W�F�N�g��������Ƃ��Ƀ��X�g�ɒǉ�����
        if (collision.gameObject.CompareTag("Command"))
        {
            colliders.Add(collision.collider);
            //ShowListContentsInTheDebugLog(colliders);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // ������I�u�W�F�N�g�����ꂽ�Ƃ��Ƀ��X�g����폜����
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
