using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour
{
    public BombMissileAttackSettings HomingenergyAttackSettings;

    public void HomingenergyInitialize()
    {
        HomingenergyAttackSettings.spawnValue = 0;
    }

    public void HomingenergyAttack()
    {
        // タイマー更新
        HomingenergyAttackSettings.timer += Time.deltaTime;

        // 一定時間ごとに生成
        if (HomingenergyAttackSettings.timer >= HomingenergyAttackSettings.spawnInterval &&
            HomingenergyAttackSettings.spawnValue < HomingenergyAttackSettings.maxSpawnValue) // 最大生成数に達していないか
        {
            HomingenergyAttackSettings.timer = 0f;
            HomingenergyAttackSettings.spawnValue++;

            // エネミーの位置に生成
            Transform enemyTransform = GameObject.FindWithTag("Enemy").transform;
            Vector3 spawnPos = new Vector3(0f, 2f, 0f);
            Instantiate(HomingenergyAttackSettings.prefab, spawnPos, Quaternion.identity);
        }
    }
}
