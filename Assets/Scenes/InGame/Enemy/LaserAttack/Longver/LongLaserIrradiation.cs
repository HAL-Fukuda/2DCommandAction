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
        [Header("いじらないで")]
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

    // レーザー照射
    public void LongLaserIrradiation()
    {
        // タイマー更新
        longlaserirradiationSettings.timer += Time.deltaTime;

        // 一定時間ごとに生成
        if (longlaserirradiationSettings.spawnValue < longlaserirradiationSettings.maxSpawnValue) // 最大生成数に達していないか
        {
            longlaserirradiationSettings.timer = 0f;
            longlaserirradiationSettings.spawnValue++;

            // エネミーの頭上辺りに生成
            Vector3 spawnPos = new Vector3(0f, 7f, 0f);

            Instantiate(longlaserirradiationSettings.LaserPoint, spawnPos, Quaternion.identity);
        }
    }


}
