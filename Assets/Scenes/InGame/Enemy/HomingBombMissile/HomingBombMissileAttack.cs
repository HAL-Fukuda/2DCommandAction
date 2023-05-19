using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour
{
    public BombMissileAttackSettings HomingBombMissileAttackSettings;

    public void HomingBombMissileInitialize()
    {
        HomingBombMissileAttackSettings.spawnValue = 0;
    }

    public void HomingBombMissileAttack()
    {
        // タイマー更新
        HomingBombMissileAttackSettings.timer += Time.deltaTime;

        // 一定時間ごとに生成
        if (HomingBombMissileAttackSettings.timer >= HomingBombMissileAttackSettings.spawnInterval &&
            HomingBombMissileAttackSettings.spawnValue < HomingBombMissileAttackSettings.maxSpawnValue) // 最大生成数に達していないか
        {
            HomingBombMissileAttackSettings.timer = 0f;
            HomingBombMissileAttackSettings.spawnValue++;

            // エネミーの位置に生成
            Transform enemyTransform = GameObject.FindWithTag("Enemy").transform;
            Vector3 spawnPos = enemyTransform.position;
            Instantiate(HomingBombMissileAttackSettings.prefab, spawnPos, Quaternion.identity);
        }
    }
}