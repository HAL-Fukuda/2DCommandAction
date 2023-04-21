using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings nailAttackSettings;

    public void NailAttack()
    {
        nailAttackSettings.timer += Time.deltaTime;

        if (nailAttackSettings.timer >= nailAttackSettings.spawnInterval)
        {
            nailAttackSettings.timer = 0f;
            //GameObject nail = Instantiate(nailAttackSettings.prefab, transform.position, Quaternion.identity);

            // プレイヤーオブジェクトを取得する
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                // プレイヤーオブジェクトの座標を取得する
                Vector3 spawnPosition = playerObject.transform.position;

                // プレハブをスポーンする
                GameObject nail = Instantiate(nailAttackSettings.prefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
