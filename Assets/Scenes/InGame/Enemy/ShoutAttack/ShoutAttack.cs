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
        [Header("������Ȃ���")]
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
        // �ő吶�����ɒB���Ă��邩
        if(shoutAttackSettings.spawnValue < shoutAttackSettings.maxSpawnValue)
        {
            // ���������Z
            shoutAttackSettings.spawnValue++;

            // �����ʒu��ݒ�
            GameObject enemy = GameObject.FindWithTag("Enemy");
            Vector3 spawnPos = enemy.transform.position;

            // ��������
            Instantiate(shoutAttackSettings.prefab, spawnPos, Quaternion.identity);
        }
    }
}
