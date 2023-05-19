using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings FlameSplashSettings;
    private float FSspeed = 7.0f; // 速度
    private Rigidbody2D FSrgd;
    private Vector3 FSPosition;

    private GameObject FSobj;

    private bool FSflg = true;
    private int FScount = 1;


    void GetPlayerPositionToFS()
    {
        // ゲームオブジェクトのTransformコンポーネントを取得する
        //Transform myObjectTransform = player1.GetComponent<Transform>();

        GameObject PlayerObject = GameObject.Find("Player");

        FSPosition = PlayerObject.transform.position;
        FSPosition.y -= 2.5f;
        FSPosition.z = 0.0f;
        //Debug.Log(FOPosition);
    }

    void GetEnemyPositionFS()
    {
        // ゲームオブジェクトのTransformコンポーネントを取得する
        //Transform enemyObjectTransform = Enemy.GetComponent<Transform>();

        //GameObject EnemyObject = GameObject.Find("Spider(Clone)");
        GameObject EnemyObject = GameObject.FindWithTag("Enemy");

        EnemyPos = EnemyObject.transform.position;
    }

    void FSflgTrue()
    {
        FSflg = true;
        FScount++;
    }

    public void FlameSplash()
    {
        if (FSflg)
        {

            GetPlayerPositionToFS();
            GetEnemyPositionFS();

            spawnPos = new Vector3(EnemyPos.x, EnemyPos.y, 0.0f);
            FSobj = Instantiate(FlameSplashSettings.prefab, spawnPos, Quaternion.identity);
            FSrgd = FSobj.GetComponent<Rigidbody2D>();


            FSrgd.AddForce(FSPosition * 10.0f);  // プレイヤーの位置に力をかける

            ////角度調整用スクリプト
            //// point1から見たpoint2の相対座標を計算
            //Vector3 relativePos = EnemyPos - FOPosition;
            //// atan2関数を用いて角度を計算
            //float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            //FOobj.transform.DORotate(new Vector3(0, 0, angle), 0, RotateMode.WorldAxisAdd);    // 攻撃エフェクトの向きの処理

            FSflg = false;

            if (FScount < 10)
            {
                Invoke("FSflgTrue", 0.3f);
                Debug.Log(FScount);
            }
            else
            {
                FScount = 0;
                Invoke("FSflgTrue", FlameSplashSettings.spawnInterval);
            }
        }

    }
}
