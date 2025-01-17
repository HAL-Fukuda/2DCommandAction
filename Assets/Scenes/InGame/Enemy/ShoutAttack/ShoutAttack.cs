using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour
{
    [System.Serializable]
    public struct ShoutAttackSettings
    {
        public GameObject prefab;
        public int maxSpawnValue;
        [SerializeField]
        [Header("いじらないで")]
        public int spawnValue;

        public ShoutAttackSettings(GameObject prefab, int maxSpawnValue)
        {
            this.prefab = prefab;
            this.maxSpawnValue = maxSpawnValue;
            this.spawnValue = 0;
        }
    }

    public ShoutAttackSettings shoutAttackSettings;

    public void ShoutAttackInitialize()
    {
        shoutAttackSettings.spawnValue = 0;
    }

    public void ShoutAttack()
    {
        // 最大生成数に達しているか
        if(shoutAttackSettings.spawnValue < shoutAttackSettings.maxSpawnValue)
        {
            // 生成数加算
            shoutAttackSettings.spawnValue++;

            // 生成位置を設定
            GameObject enemy = GameObject.FindWithTag("Enemy");
            Vector3 spawnPos = enemy.transform.position;

            // 生成する
            Instantiate(shoutAttackSettings.prefab, spawnPos, Quaternion.identity);
        }
    }
}
