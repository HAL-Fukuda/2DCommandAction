using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings snowballAttackSettings;

    public void SnowBallAttack()
    {
        snowballAttackSettings.timer += Time.deltaTime;

        if (snowballAttackSettings.timer >= snowballAttackSettings.spawnInterval)
        {
            snowballAttackSettings.timer = 0f;

            // 画面左端にオブジェクトを生成する
            Vector3 spawnPos = new Vector3(-10f, Random.Range(2.5f, 3.3f), 0f);
            GameObject obj = Instantiate(snowballAttackSettings.prefab, spawnPos, Quaternion.identity);

            obj.transform.DOMoveX(
                30f, //移動量
                snowballAttackSettings.life // 演出時間
            ).OnComplete(() =>
            {
                Destroy(obj);
            });
        }
    }
}