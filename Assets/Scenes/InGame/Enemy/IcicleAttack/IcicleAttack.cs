using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour //クラス名統一
{
    public AttackSettings icicleAttackSettings;


    public void IcicleAttack()
    {

        icicleAttackSettings.timer += Time.deltaTime;

        if (icicleAttackSettings.timer >= icicleAttackSettings.spawnInterval)
        {
            icicleAttackSettings.timer = 0f;

            // 画面外にオブジェクトを生成する
            Vector3 spawnPos = new Vector3(Random.Range(-10f, 10f), 7f, 0f);//Random.Range(-10f, 10f), 7f, 0f
            GameObject obj = Instantiate(icicleAttackSettings.prefab, spawnPos, Quaternion.identity);

            obj.transform.DOMoveY(
                -30f, //移動量
                icicleAttackSettings.life // 演出時間
            ).OnComplete(() =>
            {

                Destroy(obj);
            });
        }
    }
}