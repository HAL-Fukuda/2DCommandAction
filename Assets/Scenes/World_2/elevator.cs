using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class elevator : MonoBehaviour
{
    public float movedistance = 2.0f;
    public float moveDuration = 2.0f; // �ړ��ɂ����鎞��

    public bool UpTrigger = false;
    public bool DownTrigger = false;

    private bool isMovingUp = true; // ���ݏ㏸�����ǂ���
    public float interval = 2.0f; // �㏸�Ɖ��~�̐؂�ւ����ԊԊu

    public bool isPaused = false;

    void Start()
    {
        // interval�b���Ƃ�ChangeDirection���\�b�h���J��Ԃ��Ăяo��
        InvokeRepeating("ChangeDirection", interval, interval);
    }

    void ChangeDirection()
    {
        if (!isPaused)
        {
            isMovingUp = !isMovingUp;
            if (isMovingUp)
            {
                UpTrigger = true;
            }
            if (!isMovingUp)
            {
                DownTrigger = true;
            }
        }
    }

    void Update()
    {
        if (UpTrigger)
        {
            UpUpdate();
        }
        if (DownTrigger)
        {
            DownUpdate();
        }
    }

    public void UpUpdate()
    {
        transform.DOMoveY(transform.position.y + movedistance, moveDuration);
        UpTrigger = false;
    }

    public void DownUpdate()
    {
        transform.DOMoveY(transform.position.y - movedistance, moveDuration);
        DownTrigger = false;
    }
}
