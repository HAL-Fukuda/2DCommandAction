using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings pofflamesSettings;

    public void PofflamesAttack()
    {

        // 画面外にオブジェクトを生成する位置を3か所に固定する
        Vector3[] spawnPositions = new Vector3[]
        {
                new Vector3(-5f, -7f, 0f),   // 位置1
                new Vector3(0f, -7f, 0f),    // 位置2
                new Vector3(5f, -7f, 0f)     // 位置3
        };

        for (int i = 0; i < spawnPositions.Length; i++)
        {
            Vector3 spawnPos = spawnPositions[i];
            GameObject obj = Instantiate(pofflamesSettings.prefab, spawnPos, Quaternion.identity);

            obj.transform.DOMoveY(
                30f, // 移動量
                pofflamesSettings.life // 演出時間
            ).OnComplete(() =>
            {
                Destroy(obj);
            });
        }

    }
}
