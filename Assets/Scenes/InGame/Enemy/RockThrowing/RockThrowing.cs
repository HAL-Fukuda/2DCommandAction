using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings RockThrowingSettings;
    private float RTspeed = 9.0f; // 速度
    private Rigidbody2D RTrgd;
    private Vector3 RTPosition;

    private GameObject RTobj;

    private bool RTflg = true;
    private int RTcount = 1;


    void GetPlayerPositionToRT()
    {
        // ゲームオブジェクトのTransformコンポーネントを取得する
        //Transform myObjectTransform = player1.GetComponent<Transform>();

        GameObject PlayerObject = GameObject.Find("Player");

        RTPosition = PlayerObject.transform.position;
        RTPosition.y -= 2.5f;
        RTPosition.z = 0.0f;
        //Debug.Log(FOPosition);
    }

    void GetEnemyPositionRT()
    {
        // ゲームオブジェクトのTransformコンポーネントを取得する
        //Transform enemyObjectTransform = Enemy.GetComponent<Transform>();

        //GameObject EnemyObject = GameObject.Find("Spider(Clone)");
        GameObject EnemyObject = GameObject.FindWithTag("Enemy");

        EnemyPos = EnemyObject.transform.position;
    }

    void RTflgTrue()
    {
        RTflg = true;
        RTcount++;
    }

    public void RockThrowing()
    {
        if (RTflg)
        {

            GetPlayerPositionToRT();
            GetEnemyPositionRT();

            spawnPos = new Vector3(EnemyPos.x, EnemyPos.y, 0.0f);
            RTobj = Instantiate(RockThrowingSettings.prefab, spawnPos, Quaternion.identity);
            RTrgd = RTobj.GetComponent<Rigidbody2D>();


            RTrgd.AddForce(RTPosition * 10.0f);  // プレイヤーの位置に力をかける

            ////角度調整用スクリプト
            //// point1から見たpoint2の相対座標を計算
            //Vector3 relativePos = EnemyPos - FOPosition;
            //// atan2関数を用いて角度を計算
            //float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            //FOobj.transform.DORotate(new Vector3(0, 0, angle), 0, RotateMode.WorldAxisAdd);    // 攻撃エフェクトの向きの処理

            RTflg = false;

            if (RTcount < 3)
            {
                Invoke("RTflgTrue", 0.7f);
                Debug.Log(RTcount);
            }
            else
            {
                RTcount = 0;
                Invoke("RTflgTrue", RockThrowingSettings.spawnInterval);
            }
        }

    }
}
