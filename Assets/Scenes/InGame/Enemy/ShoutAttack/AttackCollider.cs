using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    private static LifeManager lifeManager;
    public bool oneceHit; // １度しか当たらないように
    public int damage = 1; // ダメージ数
    private bool oneceFlag = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // プレイヤーに当たったら
        if (other.gameObject.CompareTag("Player"))
        {
            // 一度しか当たらないように
            if (oneceHit)
            {
                if (oneceFlag)
                {
                    return;
                }

                oneceFlag = true;
            }

            // LifeManagerスクリプトがアタッチされているオブジェクトを取得する
            GameObject lifeManagerObject = GameObject.Find("Life");

            // LifeManagerコンポーネントを取得する
            lifeManager = lifeManagerObject.GetComponent<LifeManager>();

            // プレイヤーにダメージを与える
            lifeManager.GetDamage(damage);
        }
    }
}
