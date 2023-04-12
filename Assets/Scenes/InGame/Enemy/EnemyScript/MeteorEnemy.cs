using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour //クラス名統一
{
    public AttackSettings meteorAttackSettings;
   

    public void MeteorAttack()
    {

        meteorAttackSettings.timer += Time.deltaTime;

        if (meteorAttackSettings.timer >= meteorAttackSettings.spawnInterval)
        {
            meteorAttackSettings.timer = 0f;

            // 画面外にオブジェクトを生成する
            Vector3 spawnPos = new Vector3(Random.Range(-10f, 10f), 7f, 0f);//Random.Range(-10f, 10f), 7f, 0f
            GameObject obj = Instantiate(meteorAttackSettings.prefab, spawnPos, Quaternion.identity);

            obj.transform.DOMoveY(
                -30f, //移動量
                meteorAttackSettings.life // 演出時間
            ).OnComplete(() =>
            {
               
                Destroy(obj);
            });
        }
    }
}
