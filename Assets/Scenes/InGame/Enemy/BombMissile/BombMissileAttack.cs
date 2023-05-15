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
        [Header("������Ȃ���")]
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
        // �^�C�}�[�X�V
        bombMissileAttackSettings.timer += Time.deltaTime;

        // ��莞�Ԃ��Ƃɐ���
        if (bombMissileAttackSettings.timer >= bombMissileAttackSettings.spawnInterval &&
            bombMissileAttackSettings.spawnValue < bombMissileAttackSettings.maxSpawnValue) // �ő吶�����ɒB���Ă��Ȃ���
        {
            bombMissileAttackSettings.timer = 0f;
            bombMissileAttackSettings.spawnValue++;

            // �G�l�~�[�̈ʒu�ɐ���
            Transform enemyTransform = GameObject.FindWithTag("Enemy").transform;
            Vector3 spawnPos = enemyTransform.position;
            spawnPos.z += 1;
            Instantiate(bombMissileAttackSettings.prefab, spawnPos, Quaternion.identity);
        }
    }
}