using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour
{
    [System.Serializable]
    public struct BombMissileAttackSettings
    {
        public GameObject prefab;
        public float spawnInterval;
        public int maxSpawnValue;
        [SerializeField]
        [Header("いじらないで")]
        public int spawnValue;
        public float timer;

        public BombMissileAttackSettings(GameObject prefab, float spawnInterval, int maxSpawnValue)
        {
            this.prefab = prefab;
            this.spawnInterval = spawnInterval;
            this.maxSpawnValue = maxSpawnValue;
            this.spawnValue = 0;
            this.timer = 0.0f;
        }
    }

    public BombMissileAttackSettings bombMissileAttackSettings;

    public void BombMissileInitialize()
    {
        bombMissileAttackSettings.spawnValue = 0;
    }

    public void BombMissileAttack()
    {
        // タイマー更新
        bombMissileAttackSettings.timer += Time.deltaTime;

        // 一定時間ごとに生成
        if (bombMissileAttackSettings.timer >= bombMissileAttackSettings.spawnInterval &&
            bombMissileAttackSettings.spawnValue < bombMissileAttackSettings.maxSpawnValue) // 最大生成数に達していないか
        {
            bombMissileAttackSettings.timer = 0f;
            bombMissileAttackSettings.spawnValue++;

            // エネミーの位置に生成
            Transform enemyTransform = GameObject.FindWithTag("Enemy").transform;
            Vector3 spawnPos = enemyTransform.position;
            spawnPos.z += 1;
            Instantiate(bombMissileAttackSettings.prefab, spawnPos, Quaternion.identity);
        }
    }
}