using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcusPoint : MonoBehaviour
{
    public ParticleSystem bulletsObj;  //生成するPrefab

    private GameObject playerObj;  //Playerの位置
    private Transform target;

    private GameObject enemyObj;  //Enemyの位置
    private Vector3 enemyPos;

    private ParticleSystem _bulletsInstance;  //生成用

    private float forcusTimer;   //経過時間
    private float speed = 25f;  //追従速度

    private bool oneceShot = false;  //一回だけ呼ぶように

    void Start()
    {
        //Enemyの位置を取得
        enemyObj = GameObject.FindWithTag("Enemy");
        enemyPos = enemyObj.transform.position;
        //タイマーの初期化
        forcusTimer = 0f;
        //一回だけ呼ぶように
        oneceShot = true;
    }
    
    void FixedUpdate()
    {
        forcusTimer += Time.deltaTime;

        //Playerの位置を取得
        playerObj = GameObject.FindWithTag("Player");
        target = playerObj.transform;

        //生成から1秒間Playerを追従
        if (forcusTimer <= 1f)
        {
            ForcusMove();
        }

        //生成から1秒後に生成
        if (forcusTimer >= 1f)
        {
            if (oneceShot)
            {
                BulletsSpawn();
                oneceShot = false;
            }
        }

        //生成から3.5秒後に破壊
        if (forcusTimer >= 3.5f)
        {
            Destroy(this.gameObject);
        }
    }

    //Playerを追従
    void ForcusMove()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(target.transform.position.x, target.transform.position.y + 1), speed * Time.deltaTime);
    }

    //生成
    void BulletsSpawn()
    {
        _bulletsInstance = Instantiate(bulletsObj, enemyPos, Quaternion.identity);
    }
}
