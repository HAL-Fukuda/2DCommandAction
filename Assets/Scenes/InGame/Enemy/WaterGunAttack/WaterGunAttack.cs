using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings WatergunSettings;
    public AudioClip soundClip; // 音声ファイル
    private bool hasExecuted = false;

    public void WaterGunAttack()
    {
        if (!hasExecuted)
        {
            hasExecuted = true;

            // ランダムな方向を決定する
            bool moveRight = Random.value < 0.5f; // 50%の確率で右方向に移動する

            // 画面左端または右端にオブジェクトを生成する
            float spawnX = moveRight ? -12f : 12f;
            Vector3 spawnPos = new Vector3(spawnX, -1.76f, 0f);

            // 移動量と目標位置を設定する
            float moveAmount = moveRight ? 40f : 40f;
            Vector3 targetPos = new Vector3(spawnPos.x + moveAmount, spawnPos.y, spawnPos.z);

            GameObject obj = Instantiate(WatergunSettings.prefab, spawnPos, Quaternion.identity);

            // AudioSourceコンポーネントを追加して音を再生する
            AudioSource audioSource = obj.AddComponent<AudioSource>();
            audioSource.clip = soundClip;
            audioSource.Play();

            obj.transform.DOMove(
                targetPos, // 目標位置
                WatergunSettings.life // 演出時間
            ).OnComplete(() =>
            {
                Destroy(obj);
                hasExecuted = false; // 再度実行するためにフラグをリセット
            });
        }
    }
}
