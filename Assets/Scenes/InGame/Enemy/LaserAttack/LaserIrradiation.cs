using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public struct LaserIrradiationSettings
    {
        public GameObject LaserPoint;
        public float spawnInterval;
        public int maxSpawnValue;
        [SerializeField]
        [Header("いじらないで")]
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

    // レーザー照射
    public void LaserIrradiation()
    {
        // タイマー更新
        laserirradiationSettings.timer += Time.deltaTime;

        // 一定時間ごとに生成
        if (laserirradiationSettings.timer >= laserirradiationSettings.spawnInterval &&
            laserirradiationSettings.spawnValue < laserirradiationSettings.maxSpawnValue) // 最大生成数に達していないか
        {
            laserirradiationSettings.timer = 0f;
            laserirradiationSettings.spawnValue++;

            // エネミーの頭上辺りに生成
            Vector3 spawnPos = new Vector3(0f, 7f, 0f);

            switch (Random.Range(0, 3))
            {
                case 0:
                    Instantiate(laserirradiationSettings.LaserPoint, spawnPos, Quaternion.identity);
                    break;
            }
        }
    }

    public void LaserIrradiationInitialize()
    {
        laserirradiationSettings.spawnValue = 0;
    }
}
