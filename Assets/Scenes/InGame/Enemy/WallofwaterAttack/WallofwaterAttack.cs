using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings wofwaterSettings;
    public AudioClip WOWsound; // 音声ファイル
    private bool WOWflag = false;

    public void WofwaterAttack()
    {
        if (!WOWflag)
        {
            WOWflag = true;

            // 画面外にオブジェクトを生成する位置を2か所に固定する
            Vector3[] spawnPositions = new Vector3[]
            {
                new Vector3(-8f, -10f, 0f),   // 位置1
                new Vector3(8f, -10f, 0f)     // 位置2
            };

            for (int i = 0; i < spawnPositions.Length; i++)
            {
                Vector3 spawnPos = spawnPositions[i];
                GameObject obj = Instantiate(wofwaterSettings.prefab, spawnPos, Quaternion.identity);

                // AudioSourceコンポーネントを追加して音声を再生する
                AudioSource audioSource = obj.AddComponent<AudioSource>();
                audioSource.clip = WOWsound;
                audioSource.Play();

                obj.transform.DOMoveY(
                    spawnPos.y + 11f, // 上昇目標位置
                    3f // 上昇時間
                ).OnComplete(() =>
                {
                    StartCoroutine(StopAndDescend(obj, spawnPos, 10f)); // 上昇後の停止と下降処理を開始
                });
            }
        }
    }

    IEnumerator StopAndDescend(GameObject obj, Vector3 spawnPos, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        obj.transform.DOMoveY(
            spawnPos.y, // 下降目標位置（生成位置）
            3f // 下降時間
        ).OnComplete(() =>
        {
            StartCoroutine(DelayedDestroy(obj, 3f)); // 3秒後にオブジェクトを消去
        });

        // AudioSourceコンポーネントを停止して音声再生を中断
        AudioSource audioSource = obj.GetComponent<AudioSource>();
        audioSource.Stop();

        // 再度実行できるようにフラグをリセット
        WOWflag = false;
    }

    IEnumerator DelayedDestroy(GameObject obj, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        Destroy(obj);
    }
}
