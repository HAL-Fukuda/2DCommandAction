using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    private LifeManager lifeManager;
    public bool oneceHit; // １度しか当たらないように
    public int damage = 1; // ダメージ数

    void Start()
    {
        // LifeManagerスクリプトがアタッチされているオブジェクトを取得する
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManagerコンポーネントを取得する
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // プレイヤーに当たったら
        if (other.gameObject.CompareTag("Player"))
        {
            if (oneceHit)
            {
                // 当たり判定を消す
                BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
                boxCollider.enabled = false;
            }

            // プレイヤーにダメージを与える
            lifeManager.GetDamage(damage);
        }
    }
}
