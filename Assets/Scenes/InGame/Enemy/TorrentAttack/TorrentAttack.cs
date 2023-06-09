using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings TorrentSettings;
    public AudioClip TRsound; // 音声ファイル
    private bool TRflag = false;

    public void TorrentAttack()
    {
        if (!TRflag)
        {
            TRflag = true;

            // ランダムな方向を決定する
            bool moveRight = Random.value < 0.5f; // 50%の確率で右方向に移動する

            // プレイヤーのy座標を取得する
            float playerY = GameObject.FindGameObjectWithTag("Player").transform.position.y + 0.5f;

            // 画面左端または右端にオブジェクトを生成する
            float spawnX = moveRight ? -12f : 12f;
            Vector3 spawnPos = new Vector3(spawnX, playerY, 0f);

            // 移動量と目標位置を設定する
            float moveAmount = moveRight ? 40f : -40f; // 右から生成された場合は-40f、左から生成された場合は40f
            Vector3 targetPos = new Vector3(spawnPos.x + moveAmount, spawnPos.y, spawnPos.z);

            GameObject obj = Instantiate(TorrentSettings.prefab, spawnPos, Quaternion.identity);

            // AudioSourceコンポーネントを追加して音を再生する
            AudioSource audioSource = obj.AddComponent<AudioSource>();
            audioSource.clip = TRsound;
            audioSource.Play();

            obj.transform.DOMove(
                targetPos, // 目標位置
                TorrentSettings.life // 演出時間
            ).OnComplete(() =>
            {
                Destroy(obj);
                TRflag = false; // 再度実行するためにフラグをリセット
            });
        }
    }
}
