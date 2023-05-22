using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    [System.Serializable]
    public struct IceThornSettings
    {
        public GameObject icethorn1;
        public GameObject icethorn2;
        public GameObject icethorn3;
        public float spawnInterval;
        public int maxSpawnValue;
        [SerializeField]
        [Header("いじらないで")]
        public int spawnValue;
        public float timer;

        public IceThornSettings(GameObject prefab1, GameObject prefab2, GameObject prefab3, float spawnInterval, int maxSpawnValue)
        {
            this.icethorn1 = prefab1;
            this.icethorn2 = prefab2;
            this.icethorn3 = prefab3;
            this.spawnInterval = spawnInterval;
            this.maxSpawnValue = maxSpawnValue;
            this.spawnValue = 0;
            this.timer = 0.0f;
        }
    }
    public IceThornSettings iceThornSettings;

    public void IceThornInitialize()
    {
        iceThornSettings.spawnValue = 0;
    }

    // 羽飛ばし攻撃
    public void IceThorn()
    {
        // タイマー更新
        iceThornSettings.timer += Time.deltaTime;

        // 一定時間ごとに生成
        if (iceThornSettings.timer >= iceThornSettings.spawnInterval &&
            iceThornSettings.spawnValue < iceThornSettings.maxSpawnValue) // 最大生成数に達していないか
        {
            iceThornSettings.timer = 0f;
            iceThornSettings.spawnValue++;

            // エネミーの頭上辺りに生成
            Vector3 spawnPos = new Vector3(Random.Range(-10f, 10f), 7f, 0f);

            switch (Random.Range(0, 3))
            {
                case 0:
                    Instantiate(iceThornSettings.icethorn1, spawnPos, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(iceThornSettings.icethorn2, spawnPos, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(iceThornSettings.icethorn3, spawnPos, Quaternion.identity);
                    break;
            }
        }
    }
}
