using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour
{
    [System.Serializable]
    public struct KamaitachiAttackSettings
    {
        public GameObject kamaitachiSpawnPos;
        public GameObject kamaitachiComing;
    }
    public KamaitachiAttackSettings kamaitachiAttackSettings;

    private float timer;
    private bool attackFlag = false;  //一回だけ生成される用
    private GameObject plyerObj;
    private Vector3 playerPos;
    private Vector3 KSpawnPos;
    private Vector3 KCSpawnPos;

    //初期化処理
    public void KamaitachiAttackInitialize()
    {
        timer = 0f;  //タイマー初期化
        attackFlag = true;  //一回だけ生成されるようにtrueに

        //プレイヤーの位置を取得
        plyerObj = GameObject.FindWithTag("Player");
        playerPos = plyerObj.transform.position;

    }

    //攻撃の関数
    public void KamaitachiAttack()
    {
        if (attackFlag)
        {
            KamaitachiSpawnPosSpawn();
            KamaitachiComingSpawn();
        }

        attackFlag = false;
    }

    void KamaitachiSpawnPosSpawn()
    {
        KSpawnPos = new Vector3(playerPos.x, 12f, 0f);  //生成する位置

        //オブジェクト生成
        GameObject KSP = Instantiate(kamaitachiAttackSettings.kamaitachiSpawnPos, KSpawnPos, Quaternion.identity);
    }

    void KamaitachiComingSpawn()
    {
        KCSpawnPos = new Vector3(playerPos.x, 4f, 0f);  //生成する位置
        //オブジェクト生成
        GameObject KC = Instantiate(kamaitachiAttackSettings.kamaitachiComing, KCSpawnPos, Quaternion.identity);
    }
}
