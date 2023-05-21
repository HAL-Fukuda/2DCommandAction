using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings BoneThrowSettings;
    private float BTspeed = 5.0f; // 速度
    private Rigidbody2D BTrgd;
    private Vector3 BTPosition;

    private GameObject BTobj;

    private bool BTflg = true;

    
    void GetPlayerPositionToBT()
    {
        // ゲームオブジェクトのTransformコンポーネントを取得する
        //Transform myObjectTransform = player1.GetComponent<Transform>();

        GameObject PlayerObject = GameObject.Find("Player");

        BTPosition = PlayerObject.transform.position;
        BTPosition.y -= 2.5f;
        BTPosition.z = 0.0f;
        //Debug.Log(BTPosition);
    }

    void GetEnemyPositionBT()
    {
        // ゲームオブジェクトのTransformコンポーネントを取得する
        GameObject EnemyObject = GameObject.FindWithTag("Enemy");

        EnemyPos = EnemyObject.transform.position;
    }

    void BTflgTrue()
    {
        BTflg = true;
    }

    public void BoneThrow()
    {
        if (BTflg)
        {

            GetPlayerPositionToBT();
            GetEnemyPositionBT();

            spawnPos = new Vector3(EnemyPos.x, EnemyPos.y, 0.0f);
            BTobj = Instantiate(BoneThrowSettings.prefab, spawnPos, Quaternion.identity);
            BTrgd = BTobj.GetComponent<Rigidbody2D>();


            BTrgd.AddForce(BTPosition * 10.0f);  // プレイヤーの位置に力をかける

            //// point1から見たpoint2の相対座標を計算
            //Vector3 relativePos = EnemyPos - BTPosition;

            //// atan2関数を用いて角度を計算
            //float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;

            // 攻撃エフェクトの向きの処理
            BTobj.transform.DORotate(new Vector3(0, 0, 360), 0.5f, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)//直線的に変化するように
                .SetLoops(-1);//永続ループ    

            BTflg = false;
            Invoke("BTflgTrue", BoneThrowSettings.spawnInterval);
        }

    }


    
}