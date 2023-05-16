using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    [System.Serializable]
    public struct BowAttackSettings
    {
        public GameObject arrow;
        public float spawnInterval;
        public int maxSpawnValue;
        [SerializeField]
        [Header("いじらないで")]
        public int spawnValue;
        public float timer;

        public BowAttackSettings(GameObject prefab1, GameObject prefab2, GameObject prefab3, float spawnInterval, int maxSpawnValue)
        {
            this.arrow = prefab1;
            this.spawnInterval = spawnInterval;
            this.maxSpawnValue = maxSpawnValue;
            this.spawnValue = 0;
            this.timer = 0.0f;
        }
    }
    public BowAttackSettings bowAttackSettings;

    public void BowAttackInitialize()
    {
        bowAttackSettings.spawnValue = 0;
    }

    // 羽飛ばし攻撃
    public void BowAttack()
    {
        // タイマー更新
        bowAttackSettings.timer += Time.deltaTime;

        // 一定時間ごとに生成
        if (bowAttackSettings.timer >= bowAttackSettings.spawnInterval &&
            bowAttackSettings.spawnValue < bowAttackSettings.maxSpawnValue) // 最大生成数に達していないか
        {
            bowAttackSettings.timer = 0f;
            bowAttackSettings.spawnValue++;

            // エネミーの頭上辺りに生成
            Vector3 spawnPos = new Vector3(Random.Range(-10f, 10f), 7f, 0f);

            Instantiate(bowAttackSettings.arrow, spawnPos, Quaternion.identity);

            //switch (Random.Range(0, 3))
            //{
            //    case 0:
            //        Instantiate(BowAttackSettings.feather1, spawnPos, Quaternion.identity);
            //        break;
            //    case 1:
            //        Instantiate(BowAttackSettings.feather2, spawnPos, Quaternion.identity);
            //        break;
            //    case 2:
            //        Instantiate(BowAttackSettings.feather3, spawnPos, Quaternion.identity);
            //        break;
        }
    }
}
