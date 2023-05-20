using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    [System.Serializable]
    public struct LaserIrradiationSettings
    {
        public GameObject LaserPoint;
        public float spawnInterval;
        public int maxSpawnValue;
        [SerializeField][Header("������Ȃ���")]
        public int spawnValue;
        public float timer;

        public LaserIrradiationSettings(GameObject prefab1, float spawnInterval, int maxSpawnValue)
        {
            this.LaserPoint = prefab1;
            this.spawnInterval = spawnInterval;
            this.maxSpawnValue = maxSpawnValue;
            this.spawnValue = 0;
            this.timer = 0.0f;
        }
    }
    
    public LaserIrradiationSettings laserirradiationSettings;

    public void LaserIrradiationInitialize()
    {
        laserirradiationSettings.spawnValue = 0;
    }

    // ���[�U�[�Ǝ�
    public void LaserIrradiation()
    {
        // �^�C�}�[�X�V
        laserirradiationSettings.timer += Time.deltaTime;

        // ��莞�Ԃ��Ƃɐ���
        if (laserirradiationSettings.spawnValue < laserirradiationSettings.maxSpawnValue) // �ő吶�����ɒB���Ă��Ȃ���
        {
            laserirradiationSettings.timer = 0f;
            laserirradiationSettings.spawnValue++;

            // �G�l�~�[�̓���ӂ�ɐ���
            Vector3 spawnPos = new Vector3(0f, 7f, 0f);

            Instantiate(laserirradiationSettings.LaserPoint, spawnPos, Quaternion.identity);
        }
    }

   
}