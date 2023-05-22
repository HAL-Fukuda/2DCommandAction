using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour
{
    [System.Serializable]
    public struct ThunderboltAttackSettings
    {
        public GameObject prefab;
        public float spawnInterval;
        public int maxSpawnValue;
        [SerializeField]
        [Header("いじらないで")]
        public int spawnValue;
        public float timer;

        public ThunderboltAttackSettings(GameObject prefab, float spawnInterval, int maxSpawnValue)
        {
            this.prefab = prefab;
            this.spawnInterval = spawnInterval;
            this.maxSpawnValue = maxSpawnValue;
            this.spawnValue = 0;
            this.timer = 0.0f;
        }
    }

    public ThunderboltAttackSettings thunderboltAttackSettings;

    public void ThunderboltAttackInitialize()
    {
        thunderboltAttackSettings.spawnValue = 0;
    }

    public void ThunderboltAttack()
    {
        // タイマー更新
        thunderboltAttackSettings.timer += Time.deltaTime;

        // 一定時間ごとに生成
        if (thunderboltAttackSettings.timer >= thunderboltAttackSettings.spawnInterval &&
            thunderboltAttackSettings.spawnValue < thunderboltAttackSettings.maxSpawnValue) // 最大生成数に達していないか
        {
            thunderboltAttackSettings.timer = 0f;
            thunderboltAttackSettings.spawnValue++;

            Vector3 spawnPos = new Vector3(Random.Range(-10f, 10f), -2.32f, 0f); // 生成位置

            Instantiate(thunderboltAttackSettings.prefab, spawnPos, Quaternion.identity);
        }
    }
}
