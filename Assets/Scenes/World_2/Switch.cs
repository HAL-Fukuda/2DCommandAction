using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Switch : MonoBehaviour
{
    public float movedistance = 1.0f;
    public float moveDuration = 1f; // �ړ��ɂ����鎞��
    private Transform elevator; // �����I�u�W�F�N�g
    private Transform conveyor;

    void Start()
    {
        elevator = GameObject.FindWithTag("elevator").transform;
        conveyor = GameObject.FindWithTag("conveyor").transform;
    }
}
