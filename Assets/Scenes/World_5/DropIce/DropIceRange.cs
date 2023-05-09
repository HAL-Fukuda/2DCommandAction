using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DropIceRange : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] private GameObject dropIcePrefab;  //��������X��Prefab
    [SerializeField] private Transform dropIceRange;  //��������͈�
    [SerializeField] private GameObject rangePrefab;  //��������͈�

    private float moveSpeed = 2f;
    private Vector3 rangePos;  //Range�̌��݈ʒu
    private Vector3 startPos = new Vector3(15, 12, 0);  //��ʉE��
    private Vector3 endPos = new Vector3(-15, 12, 0);   //��ʍ���
    public int rangeMoveMode;  //�ړ��̕��@��؂�ւ���p
    private bool rangeMoveEnd = false;  //�ړ�����������

    private float randomPosX, randomPosY, randomPosZ;
    private float dropInterval = 0.01f;  //��������Ԋu0.03
    private float dropTimer;     //�^�C�}�[
    //public float moveTime;  //DoTween�ňړ��Ɋ|���鎞��
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();   
    }
    
    void FixedUpdate()
    {
        rangePos = this.transform.localPosition;

        CheckRange();
        RangeMove();

        //��������
        CreateRandomPos();
        dropTimer += Time.deltaTime;

        if (dropTimer >= dropInterval)
        {
            SpawnIce();
            dropTimer = 0.0f;
        }
    }

    //�����͈͂̈ړ�����
    void RangeMove()
    {
        Debug.Log(rangeMoveEnd);

        switch (rangeMoveMode)
        {
            //�J��Ԃ�
            case 1:
                if (rangeMoveEnd)
                {
                    rb.velocity = new Vector3(moveSpeed, 0, 0);   //������E
                }
                else
                {
                    rb.velocity = new Vector3(-moveSpeed, 0, 0);  //�E���獶
                }
                break;
            //��蒼��
            case 2:  
                if (rangeMoveEnd)
                {
                    SpawnRange();
                    rangeMoveEnd = false;
                    Destroy(this.gameObject);
                }
                else
                {
                    rb.velocity = new Vector3(-moveSpeed, 0, 0);  //�E���獶
                }
                break;
        }
    }

    //Range�̌��݈ʒu�Ńt���O���Ǘ�
    void CheckRange()
    {
        float distanceST = Vector3.Distance(rangePos, startPos);
        float distanceEN = Vector3.Distance(rangePos, endPos);

        if (distanceST == 1)
        {
            rangeMoveEnd = true;
        }
        else if (distanceEN <= 1) 
        {
            rangeMoveEnd = true;
        }
    }

    //Range�𐶐�
    void SpawnRange()
    {
        Instantiate(rangePrefab, new Vector3(12, 12, 0), rangePrefab.transform.rotation);
    }

    //�X��͈͓��ɐ���
    void SpawnIce()
    {
        Instantiate(dropIcePrefab, new Vector3(randomPosX, randomPosY, randomPosZ), dropIcePrefab.transform.rotation);
    }

    //��������ʒu�������_���ɋ��߂�
    void CreateRandomPos()
    {
        float rangeSize = dropIceRange.localScale.x;
        float halfRangeSize = rangeSize / 2.0f;
        float leftBoundary = dropIceRange.position.x - halfRangeSize;
        float rightBoundary = dropIceRange.position.x + halfRangeSize;

        randomPosX = Random.Range(leftBoundary, rightBoundary);
        randomPosY = dropIceRange.position.y;
        randomPosZ = dropIceRange.position.z;
    }
}
