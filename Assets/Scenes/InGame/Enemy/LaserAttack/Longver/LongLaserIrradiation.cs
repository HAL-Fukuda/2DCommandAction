using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    [System.Serializable]
    public struct LongLaserIrradiationSettings
    {
        public GameObject LaserPoint;
        public float spawnInterval;
        public int maxSpawnValue;
        [SerializeField]
        [Header("������Ȃ���")]
        public int spawnValue;
        public float timer;

        public LongLaserIrradiationSettings(GameObject prefab1, float spawnInterval, int maxSpawnValue)
        {
            this.LaserPoint = prefab1;
            this.spawnInterval = spawnInterval;
            this.maxSpawnValue = maxSpawnValue;
            this.spawnValue = 0;
            this.timer = 0.0f;
        }
    }

    public LongLaserIrradiationSettings longlaserirradiationSettings;

    public void LongLaserIrradiationInitialize()
    {
        longlaserirradiationSettings.spawnValue = 0;
    }

    // ���[�U�[�Ǝ�
    public void LongLaserIrradiation()
    {
        // �^�C�}�[�X�V
        longlaserirradiationSettings.timer += Time.deltaTime;

        // ��莞�Ԃ��Ƃɐ���
        if (longlaserirradiationSettings.spawnValue < longlaserirradiationSettings.maxSpawnValue) // �ő吶�����ɒB���Ă��Ȃ���
        {
            longlaserirradiationSettings.timer = 0f;
            longlaserirradiationSettings.spawnValue++;

            // �G�l�~�[�̓���ӂ�ɐ���
            Vector3 spawnPos = new Vector3(0f, 7f, 0f);

            Instantiate(longlaserirradiationSettings.LaserPoint, spawnPos, Quaternion.identity);
        }
    }


}
