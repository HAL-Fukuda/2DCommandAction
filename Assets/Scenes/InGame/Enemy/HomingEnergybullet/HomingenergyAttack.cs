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
        // �^�C�}�[�X�V
        HomingenergyAttackSettings.timer += Time.deltaTime;

        // ��莞�Ԃ��Ƃɐ���
        if (HomingenergyAttackSettings.timer >= HomingenergyAttackSettings.spawnInterval &&
            HomingenergyAttackSettings.spawnValue < HomingenergyAttackSettings.maxSpawnValue) // �ő吶�����ɒB���Ă��Ȃ���
        {
            HomingenergyAttackSettings.timer = 0f;
            HomingenergyAttackSettings.spawnValue++;

            // �G�l�~�[�̈ʒu�ɐ���
            Transform enemyTransform = GameObject.FindWithTag("Enemy").transform;
            Vector3 spawnPos = new Vector3(0f, 2f, 0f);
            Instantiate(HomingenergyAttackSettings.prefab, spawnPos, Quaternion.identity);
        }
    }
}
