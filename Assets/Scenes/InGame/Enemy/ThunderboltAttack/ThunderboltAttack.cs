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
        [Header("������Ȃ���")]
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
        // �^�C�}�[�X�V
        thunderboltAttackSettings.timer += Time.deltaTime;

        // ��莞�Ԃ��Ƃɐ���
        if (thunderboltAttackSettings.timer >= thunderboltAttackSettings.spawnInterval &&
            thunderboltAttackSettings.spawnValue < thunderboltAttackSettings.maxSpawnValue) // �ő吶�����ɒB���Ă��Ȃ���
        {
            thunderboltAttackSettings.timer = 0f;
            thunderboltAttackSettings.spawnValue++;

            Vector3 spawnPos = new Vector3(Random.Range(-10f, 10f), -2.32f, 0f); // �����ʒu

            Instantiate(thunderboltAttackSettings.prefab, spawnPos, Quaternion.identity);
        }
    }
}
