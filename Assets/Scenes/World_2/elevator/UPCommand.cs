using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UPCommand : MonoBehaviour
{
    public float movedistance = 1.0f;
    public float moveDuration = 1f; // �ړ��ɂ����鎞��

    private bool touched = false; // �I�u�W�F�N�g�ɐG�ꂽ���ǂ���
    private Transform elevator; // �����I�u�W�F�N�g

    void Start()
    {
        // �V�[������"elevator"�I�u�W�F�N�g����������
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
            touched = false; // 1�񂾂��ړ�����悤�Ƀt���O���I�t�ɂ���
        }
    }
}
