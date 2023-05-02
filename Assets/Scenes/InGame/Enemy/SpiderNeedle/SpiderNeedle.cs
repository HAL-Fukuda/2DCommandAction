using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings SpiderNeedleSettings;
    private float SNspeed = 5.0f; // 速度
    private Rigidbody2D SNrgd;
    private Vector3 SNPosition;

    private GameObject SNobj;

    private bool SNflg = true;


    void GetPlayerPositionToSN()
    {
        // ゲームオブジェクトのTransformコンポーネントを取得する
        //Transform myObjectTransform = player1.GetComponent<Transform>();

        GameObject PlayerObject = GameObject.Find("Player");

        SNPosition = PlayerObject.transform.position;
        SNPosition.y -= 2.5f;
        SNPosition.z = 0.0f;
        //Debug.Log(SNPosition);
    }

    void GetEnemyPositionSN()
    {
        // ゲームオブジェクトのTransformコンポーネントを取得する
        //Transform enemyObjectTransform = Enemy.GetComponent<Transform>();

        //GameObject EnemyObject = GameObject.Find("Spider(Clone)");
        GameObject EnemyObject = GameObject.Find("Enemy");

        EnemyPos = EnemyObject.transform.position;
    }

    void SNflgTrue()
    {
        SNflg = true;
    }

    public void SpiderNeedle()
    {
        if (SNflg)
        {

            GetPlayerPositionToSN();
            GetEnemyPositionSN();

            spawnPos = new Vector3(EnemyPos.x, EnemyPos.y, 0.0f);
            SNobj = Instantiate(SpiderNeedleSettings.prefab, spawnPos, Quaternion.identity);
            SNrgd = SNobj.GetComponent<Rigidbody2D>();


            SNrgd.AddForce(SNPosition * 10.0f);  // プレイヤーの位置に力をかける

            // point1から見たpoint2の相対座標を計算
            Vector3 relativePos = EnemyPos - SNPosition;

            // atan2関数を用いて角度を計算
            float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;


            SNobj.transform.DORotate(new Vector3(0, 0, angle), 0, RotateMode.WorldAxisAdd);    // 攻撃エフェクトの向きの処理

            SNflg = false;
            Invoke("SNflgTrue", SpiderNeedleSettings.spawnInterval);
        }

    }


    // Update is called once per frame


    // Update二個あるってエラーでる
    // Updateを書く場所を変えるかもしれない

    //void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.B))
    //    {
    //        SideVanishAttack();
    //    }

    //    if (rgd != null)
    //    {
    //        // 速度の上限設定
    //        if (rgd.velocity.magnitude > SVAspeed)
    //        {
    //            rgd.velocity = rgd.velocity.normalized * SVAspeed;  // 最大速度を設ける
    //        }
    //    }
    //}
}
