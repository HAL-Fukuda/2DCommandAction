using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    [System.Serializable]
    public struct SporeSettings
    {
        public GameObject spore1;
        public GameObject spore2;
        public GameObject spore3;
        public float spawnInterval;
        public int maxSpawnValue;
        [SerializeField]
        [Header("������Ȃ���")]
        public int spawnValue;
        public float timer;

        public SporeSettings(GameObject prefab1, GameObject prefab2, GameObject prefab3, float spawnInterval, int maxSpawnValue)
        {
            this.spore1 = prefab1;
            this.spore2 = prefab2;
            this.spore3 = prefab3;
            this.spawnInterval = spawnInterval;
            this.maxSpawnValue = maxSpawnValue;
            this.spawnValue = 0;
            this.timer = 0.0f;
        }
    }
    public SporeSettings sporeSettings;

    public void SporeInitialize()
    {
        sporeSettings.spawnValue = 0;
    }

    // �H��΂��U��
    public void Spore()
    {
        // �^�C�}�[�X�V
        sporeSettings.timer += Time.deltaTime;

        // ��莞�Ԃ��Ƃɐ���
        if (sporeSettings.timer >= sporeSettings.spawnInterval &&
            sporeSettings.spawnValue < sporeSettings.maxSpawnValue) // �ő吶�����ɒB���Ă��Ȃ���
        {
            sporeSettings.timer = 0f;
            sporeSettings.spawnValue++;

            // �G�l�~�[�̓���ӂ�ɐ���
            Vector3 spawnPos = new Vector3(Random.Range(-10f, 10f), 7f, 0f);

            switch (Random.Range(0, 3))
            {
                case 0:
                    Instantiate(sporeSettings.spore1, spawnPos, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(sporeSettings.spore2, spawnPos, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(sporeSettings.spore3, spawnPos, Quaternion.identity);
                    break;
            }
        }
    }
}
