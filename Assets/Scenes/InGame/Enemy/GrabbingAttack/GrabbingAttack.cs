using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings GrabbingAttackSettings;

    public float GAspeed; // 速度
    private Rigidbody2D GArgd;
    private Vector3 GAPosition;

    private GameObject GAobj;

    private bool GAflg = true;


    void GetPlayerPositionToGA()
    {
        // ゲームオブジェクトのTransformコンポーネントを取得する
        //Transform myObjectTransform = player1.GetComponent<Transform>();

        GameObject PlayerObject = GameObject.FindWithTag("Player");

        GAPosition = PlayerObject.transform.position;
        //GAPosition.y -= 3.5f;
        GAPosition.z = 0.0f;
        //Debug.Log(GAPosition);
    }

    void GetEnemyPositionGA()
    {
        // ゲームオブジェクトのTransformコンポーネントを取得する
        //Transform enemyObjectTransform = Enemy.GetComponent<Transform>();

        GameObject EnemyObject = GameObject.FindWithTag("Enemy");

        EnemyPos = EnemyObject.transform.position;
    }

    void GAflgTrue()
    {
        GAflg = true;
    }

    void GAobjDestroy()
    {
        Destroy(GAobj);
    }



    public void GrabbingAttack()
    {
        if (GAflg)
        {

            GetPlayerPositionToGA();
            GetEnemyPositionGA();

            spawnPos = new Vector3(EnemyPos.x, EnemyPos.y, 0.0f);
            GAobj = Instantiate(GrabbingAttackSettings.prefab, spawnPos, Quaternion.identity);
            GArgd = GAobj.GetComponent<Rigidbody2D>();

            GAobj.transform.DOMove(GAPosition, 1.0f)
                .SetLoops(2, LoopType.Yoyo)
                .OnComplete(GAobjDestroy);

            //// point1から見たpoint2の相対座標を計算
            //Vector3 relativePos = EnemyPos - GAPosition;
            //// atan2関数を用いて角度を計算
            //float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            //GAobj.transform.DORotate(new Vector3(0, 0, angle), 0, RotateMode.WorldAxisAdd);    // 攻撃エフェクトの向きの処理


            GAflg = false;
            Invoke("GAflgTrue", GrabbingAttackSettings.spawnInterval);
        }

    }

}