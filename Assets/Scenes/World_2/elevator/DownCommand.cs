using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class Command : MonoBehaviour
{
    public void DownInitialize()
    {
        // �V�[������"elevator"�I�u�W�F�N�g����������
        elevator = GameObject.Find("elevator").transform;
    }

    public void DownUpdate()
    {
        DownInitialize();
        elevator.DOMoveY(elevator.position.y - movedistance, moveDuration);
    }
}
