using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour
{
    public struct BombAttackSettings
    {
        public GameObject prefab;
        public float spawnInterval;
        public int maxSpawnValue;
        [SerializeField]
        [Header("いじらないで")]
        public int spawnValue;
        public float timer;

        public BombAttackSettings(GameObject prefab, float spawnInterval, int maxSpawnValue)
        {
            this.prefab = prefab;
            this.spawnInterval = spawnInterval;
            this.maxSpawnValue = maxSpawnValue;
            this.spawnValue = 0;
            this.timer = 0.0f;
        }
    }

    BombAttackSettings bombAttackSettings;
    public void BombMissileInitialize()
    {
        bombAttackSettings.spawnValue = 0;
    }

    public void BombMissileAttack()
    {
        // タイマー更新
        bombAttackSettings.timer += Time.deltaTime;

        // 一定時間ごとに生成
        if (bombAttackSettings.timer >= bombAttackSettings.spawnInterval &&
            bombAttackSettings.spawnValue < bombAttackSettings.maxSpawnValue) // 最大生成数に達していないか
        {
            bombAttackSettings.timer = 0f;
            bombAttackSettings.spawnValue++;

            // エネミーの位置に生成
            Transform enemyTransform = GameObject.FindWithTag("Enemy").transform;
            Vector3 spawnPos = enemyTransform.position;
            Instantiate(bombAttackSettings.prefab, spawnPos, Quaternion.identity);
        }
    }
}