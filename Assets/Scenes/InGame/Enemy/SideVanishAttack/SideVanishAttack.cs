using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings SideVanishAttackSettings;
    public GameObject Enemy;
    private Vector3 EnemyPos;
    public float SVAspeed; // 速度
    private Rigidbody2D rgd;
    private Vector3 SVAPosition;

    private GameObject SVAobj;

    private bool SVAflg = true;


    void GetPlayerPositionToSVA()
    {
        // ゲームオブジェクトのTransformコンポーネントを取得する
        //Transform myObjectTransform = player1.GetComponent<Transform>();

        GameObject PlayerObject = GameObject.Find("Player");

        SVAPosition = PlayerObject.transform.position;
        SVAPosition.y -= 3.5f;
        SVAPosition.z = 0.0f;
        //Debug.Log(SVAPosition);
    }

    void GetEnemyPosition()
    {
        // ゲームオブジェクトのTransformコンポーネントを取得する
        //Transform enemyObjectTransform = Enemy.GetComponent<Transform>();

        GameObject EnemyObject = GameObject.FindWithTag("Enemy");

        EnemyPos = EnemyObject.transform.position;
    }

    void SVAflgTrue()
    {
        SVAflg = true;
    }

    public void SideVanishAttack()
    {
        if (SVAflg)
        {

            GetPlayerPositionToSVA();
            GetEnemyPosition();

            spawnPos = new Vector3(EnemyPos.x, EnemyPos.y, 0.0f);
            SVAobj = Instantiate(SideVanishAttackSettings.prefab, spawnPos, Quaternion.identity);
            rgd = SVAobj.GetComponent<Rigidbody2D>();


            rgd.AddForce(SVAPosition * 10.0f);  // プレイヤーの位置に力をかける

            // point1から見たpoint2の相対座標を計算
            Vector3 relativePos = EnemyPos - SVAPosition;

            // atan2関数を用いて角度を計算
            float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;


            SVAobj.transform.DORotate(new Vector3(0, 0, angle), 0, RotateMode.WorldAxisAdd);    // 攻撃エフェクトの向きの処理

            SVAflg = false;
            Invoke("SVAflgTrue", SideVanishAttackSettings.spawnInterval);
        }

    }

}
