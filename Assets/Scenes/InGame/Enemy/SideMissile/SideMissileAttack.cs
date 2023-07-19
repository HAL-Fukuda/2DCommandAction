using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour
{

    [System.Serializable]
    public struct SideMissileAttackSettings
    {
        public enum eDirection
        {
            left,
            right
        }

        public GameObject prefab;
        public float spawnInterval;
        public int maxSpawnValue;
        public eDirection direction;

        [SerializeField]
        [Header("いじらないで")]
        public int spawnValue;
        public float timer;
        public Vector3 spawnPosition;

        public SideMissileAttackSettings(GameObject prefab, float spawnInterval, int maxSpawnValue, eDirection direction)
        {
            this.prefab = prefab;
            this.spawnInterval = spawnInterval;
            this.maxSpawnValue = maxSpawnValue;
            this.direction = direction;
            this.spawnValue = 0;
            this.timer = 0.0f;
            this.spawnPosition = new Vector3(0, 0, 0);
        }
    }

    public SideMissileAttackSettings sideMissileAttackSettings;

    public void SideMissileInitialize()
    {
        // 生成個数をリセット
        sideMissileAttackSettings.spawnValue = 0;
        // 生成位置をリセット
        sideMissileAttackSettings.spawnPosition = new Vector3(0, 0, 0);

        // 発射方向を乱数で設定
        int randomNumber = new System.Random().Next(2);
        if (randomNumber == 0)
        {
            sideMissileAttackSettings.prefab.GetComponent<SideMissile>().direction = SideMissile.eDirection.right;
            sideMissileAttackSettings.direction = SideMissileAttackSettings.eDirection.right;
        }
        else if (randomNumber == 1)
        {
            sideMissileAttackSettings.prefab.GetComponent<SideMissile>().direction = SideMissile.eDirection.left;
            sideMissileAttackSettings.direction = SideMissileAttackSettings.eDirection.left;
        }
        else
        {
            // 乱数生成ができなかった場合はエラー
            Debug.Log("初期化エラー：SideMissileAttak");
            // 右向きを設定しておく
            sideMissileAttackSettings.prefab.GetComponent<SideMissile>().direction = SideMissile.eDirection.right;
            sideMissileAttackSettings.direction = SideMissileAttackSettings.eDirection.right;
        }
    }

    // 左か右からミサイル直線
    public void SideMissileAttack()
    {
        // タイマー更新
        sideMissileAttackSettings.timer += Time.deltaTime;

        // 一定時間ごとに生成
        if (sideMissileAttackSettings.timer >= sideMissileAttackSettings.spawnInterval &&
            sideMissileAttackSettings.spawnValue < sideMissileAttackSettings.maxSpawnValue) // 最大生成数に達していないか
        {
            sideMissileAttackSettings.timer = 0f;
            sideMissileAttackSettings.spawnValue++;

            // 生成位置を取得 
            if (sideMissileAttackSettings.spawnPosition == new Vector3(0, 0, 0)) // 生成位置がセットされていなければ初期位置をセットする
            {

                // 生成範囲はX11 Y7~-1 Z0
                if (sideMissileAttackSettings.direction == SideMissileAttackSettings.eDirection.right)
                {
                    sideMissileAttackSettings.spawnPosition = new Vector3(-11, 7, 0);
                }
                if (sideMissileAttackSettings.direction == SideMissileAttackSettings.eDirection.left)
                {
                    sideMissileAttackSettings.spawnPosition = new Vector3(11, 7, 0);
                }
            }

            // 生成
            Instantiate(sideMissileAttackSettings.prefab, sideMissileAttackSettings.spawnPosition, Quaternion.identity);

            // 次の生成位置を計算
            sideMissileAttackSettings.spawnPosition.y -= 1f;
        }
    }
}
