using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class Command : MonoBehaviour
{
    public float movedistance = 1.0f;
    public float moveDuration = 1f; // �ړ��ɂ����鎞��
    private Transform elevator; // �����I�u�W�F�N�g

    public void UpInitialize()
    {
        // �V�[������"elevator"�I�u�W�F�N�g����������
        elevator = GameObject.Find("elevator").transform;
    }

    public void UpUpdate()
    {
        UpInitialize();
        elevator.DOMoveY(elevator.position.y + movedistance, moveDuration);
    }
}
