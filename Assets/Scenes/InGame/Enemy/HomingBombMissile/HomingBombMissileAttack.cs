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
        // �^�C�}�[�X�V
        HomingBombMissileAttackSettings.timer += Time.deltaTime;

        // ��莞�Ԃ��Ƃɐ���
        if (HomingBombMissileAttackSettings.timer >= HomingBombMissileAttackSettings.spawnInterval &&
            HomingBombMissileAttackSettings.spawnValue < HomingBombMissileAttackSettings.maxSpawnValue) // �ő吶�����ɒB���Ă��Ȃ���
        {
            HomingBombMissileAttackSettings.timer = 0f;
            HomingBombMissileAttackSettings.spawnValue++;

            // �G�l�~�[�̈ʒu�ɐ���
            Transform enemyTransform = GameObject.FindWithTag("Enemy").transform;
            Vector3 spawnPos = enemyTransform.position;
            Instantiate(HomingBombMissileAttackSettings.prefab, spawnPos, Quaternion.identity);
        }
    }
}