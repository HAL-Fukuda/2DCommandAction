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
        [Header("������Ȃ���")]
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
        // �^�C�}�[�X�V
        bombAttackSettings.timer += Time.deltaTime;

        // ��莞�Ԃ��Ƃɐ���
        if (bombAttackSettings.timer >= bombAttackSettings.spawnInterval &&
            bombAttackSettings.spawnValue < bombAttackSettings.maxSpawnValue) // �ő吶�����ɒB���Ă��Ȃ���
        {
            bombAttackSettings.timer = 0f;
            bombAttackSettings.spawnValue++;

            // �G�l�~�[�̈ʒu�ɐ���
            Transform enemyTransform = GameObject.FindWithTag("Enemy").transform;
            Vector3 spawnPos = enemyTransform.position;
            Instantiate(bombAttackSettings.prefab, spawnPos, Quaternion.identity);
        }
    }
}