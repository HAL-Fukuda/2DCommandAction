using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DropIceRange : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] private GameObject dropIcePrefab;  //生成する氷のPrefab
    [SerializeField] private Transform dropIceRange;  //生成する範囲
    [SerializeField] private GameObject rangePrefab;  //生成する範囲

    private float moveSpeed = 2f;
    private Vector3 rangePos;  //Rangeの現在位置
    private Vector3 startPos = new Vector3(15, 12, 0);  //画面右側
    private Vector3 endPos = new Vector3(-15, 12, 0);   //画面左側
    public int rangeMoveMode;  //移動の方法を切り替える用
    private bool rangeMoveEnd = false;  //移動しきったか

    private float randomPosX, randomPosY, randomPosZ;
    private float dropInterval = 0.01f;  //生成する間隔0.03
    private float dropTimer;     //タイマー
    //public float moveTime;  //DoTweenで移動に掛ける時間
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();   
    }
    
    void FixedUpdate()
    {
        rangePos = this.transform.localPosition;

        CheckRange();
        RangeMove();

        //生成処理
        CreateRandomPos();
        dropTimer += Time.deltaTime;

        if (dropTimer >= dropInterval)
        {
            SpawnIce();
            dropTimer = 0.0f;
        }
    }

    //生成範囲の移動処理
    void RangeMove()
    {
        Debug.Log(rangeMoveEnd);

        switch (rangeMoveMode)
        {
            //繰り返し
            case 1:
                if (rangeMoveEnd)
                {
                    rb.velocity = new Vector3(moveSpeed, 0, 0);   //左から右
                }
                else
                {
                    rb.velocity = new Vector3(-moveSpeed, 0, 0);  //右から左
                }
                break;
            //やり直し
            case 2:  
                if (rangeMoveEnd)
                {
                    SpawnRange();
                    rangeMoveEnd = false;
                    Destroy(this.gameObject);
                }
                else
                {
                    rb.velocity = new Vector3(-moveSpeed, 0, 0);  //右から左
                }
                break;
        }
    }

    //Rangeの現在位置でフラグを管理
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

    //Rangeを生成
    void SpawnRange()
    {
        Instantiate(rangePrefab, new Vector3(12, 12, 0), rangePrefab.transform.rotation);
    }

    //氷を範囲内に生成
    void SpawnIce()
    {
        Instantiate(dropIcePrefab, new Vector3(randomPosX, randomPosY, randomPosZ), dropIcePrefab.transform.rotation);
    }

    //生成する位置をランダムに求める
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
