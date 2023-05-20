using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings FoxOnibiSettings;
    private float FOspeed = 7.0f; // 速度
    private Rigidbody2D FOrgd;
    private Vector3 FOPosition;

    private GameObject FOobj;

    private bool FOflg = true;
    private int FOcount = 1;


    void GetPlayerPositionToFO()
    {
        // ゲームオブジェクトのTransformコンポーネントを取得する
        //Transform myObjectTransform = player1.GetComponent<Transform>();

        GameObject PlayerObject = GameObject.Find("Player");

        FOPosition = PlayerObject.transform.position;
        FOPosition.y -= 2.5f;
        FOPosition.z = 0.0f;
        //Debug.Log(FOPosition);
    }

    void GetEnemyPositionFO()
    {
        // ゲームオブジェクトのTransformコンポーネントを取得する
        //Transform enemyObjectTransform = Enemy.GetComponent<Transform>();

        //GameObject EnemyObject = GameObject.Find("Spider(Clone)");
        GameObject EnemyObject = GameObject.FindWithTag("Enemy");

        EnemyPos = EnemyObject.transform.position;
    }

    void FOflgTrue()
    {
        FOflg = true;
        FOcount++;
    }

    public void FoxOnibi()
    {
        if (FOflg)
        {

            GetPlayerPositionToFO();
            GetEnemyPositionFO();

            spawnPos = new Vector3(EnemyPos.x, EnemyPos.y, 0.0f);
            FOobj = Instantiate(FoxOnibiSettings.prefab, spawnPos, Quaternion.identity);
            FOrgd = FOobj.GetComponent<Rigidbody2D>();


            FOrgd.AddForce(FOPosition * 10.0f);  // プレイヤーの位置に力をかける

            ////角度調整用スクリプト
            //// point1から見たpoint2の相対座標を計算
            //Vector3 relativePos = EnemyPos - FOPosition;
            //// atan2関数を用いて角度を計算
            //float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            //FOobj.transform.DORotate(new Vector3(0, 0, angle), 0, RotateMode.WorldAxisAdd);    // 攻撃エフェクトの向きの処理

            FOflg = false;

            if (FOcount < 5)
            {
                Invoke("FOflgTrue", 0.3f);
                //Debug.Log(FOcount);
            }
            else
            {
                FOcount = 0;
                Invoke("FOflgTrue", FoxOnibiSettings.spawnInterval);
            }
        }

    }
}