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


    void GetPlayerPosition()
    {
        // ゲームオブジェクトのTransformコンポーネントを取得する
        Transform myObjectTransform = player1.GetComponent<Transform>();

        SVAPosition = myObjectTransform.position;
        SVAPosition.y -= 3.5f;
        SVAPosition.z = 0.0f;
        //Debug.Log(SVAPosition);
    }

    void GetEnemyPosition()
    {
        // ゲームオブジェクトのTransformコンポーネントを取得する
        Transform enemyObjectTransform = Enemy.GetComponent<Transform>();

        EnemyPos = enemyObjectTransform.position;
    }



    void SideVanishAttack()
    {
        GetPlayerPosition();
        GetEnemyPosition();

        spawnPos = new Vector3(EnemyPos.x, EnemyPos.y, 0.0f);
        SVAobj = Instantiate(SideVanishAttackSettings.prefab, spawnPos, Quaternion.identity);
        rgd = SVAobj.GetComponent<Rigidbody2D>();


        rgd.AddForce(SVAPosition * 10.0f);  // プレイヤーの位置に力をかける
    }


    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.B))
        //{
        //    SideVanishAttack();
        //}

        if (rgd != null)
        {
            // 速度の上限設定
            if (rgd.velocity.magnitude > SVAspeed)
            {
                rgd.velocity = rgd.velocity.normalized * SVAspeed;  // 最大速度を設ける
            }
        }
    }
    
}
