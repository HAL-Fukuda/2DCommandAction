using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour //partial C++のクラス
{
    [System.Serializable]
    public struct AttackSettings
    {
        public GameObject prefab;
        public float spawnInterval;
        public float life;
        [SerializeField][Header("いじらないで")] public float timer;

        public AttackSettings(GameObject prefab, float spawnInterval, float life)
        {
            this.prefab = prefab;
            this.spawnInterval = spawnInterval;
            this.life = life;
            this.timer = 0f;
        }
    }

    private bool isReady = false;

    public void EnemyAttackInitialize()
    {
        isReady = false;
        // ここで攻撃の前兆の処理
        StartShake();
    }

    // 終了処理
    // 攻撃が終わったら呼び出す
    public void EnemyAttackFinalize()
    {
        isReady = false;
    }

    void EnemyAttackUpdate()
    {
        //MeteorAttack();
        SidewaysAttack();
        //EnemysAttack();  //最終これだけにする
    }

    public bool IsReady()
    {
        return isReady;
    }

    public void IsReadyOn()
    {
        isReady = true;
    }

    void Update()
    {
        
        // SideVanishAttackに使うやつ
        if (rgd != null)
        {
            // 速度の上限設定
            if (rgd.velocity.magnitude > SVAspeed)
            {
                rgd.velocity = rgd.velocity.normalized * SVAspeed;  // 最大速度を設ける
            }
        }

        // SpiderNeedleに使うやつ
        if (SNrgd != null)
        {
            // 速度の上限設定
            if (SNrgd.velocity.magnitude > SNspeed)
            {
                SNrgd.velocity = SNrgd.velocity.normalized * SNspeed;  // 最大速度を設ける
            }
        }

        if (Input.GetKeyUp(KeyCode.B))
        {
            SpiderNeedle();
        }
    }

    //public Enemy.eEnemyType EnemysAttack(Enemy.eEnemyType enemyType)
    //{
    //    //Debug.Log("EnemysAttack");
    //    //GameObject attackEnemy;  //攻撃している敵

    //    //attackEnemy = GameObject.FindWithTag("Enemy");
    //    //string name = attackEnemy.EnemyType;

    //    //Debug.Log(enemyType);

    //    switch (enemyType)
    //    {
    //        case Enemy.eEnemyType.Demon:
    //            //Demonの攻撃処理
    //            break;
    //    }
    //}
}
