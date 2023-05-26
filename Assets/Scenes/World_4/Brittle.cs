using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brittle : MonoBehaviour
{
    public int maxHealth = 3; // 最大HP
    public int currentHealth; // 現在のHP

    private void Start()
    {
        currentHealth = maxHealth; // 初期化
    }

    //void Update()
    //{
    //    Debug.Log(currentHealth);
    //}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerManager playerManager = collision.GetComponent<PlayerManager>();
            if (!playerManager.isGround)
            {
                currentHealth--; // HPを減らす

                if (currentHealth <= 0)
                {
                    Destroy(gameObject); // HPが0以下になったらオブジェクトを破壊する
                }
            }
        }

        if (collision.gameObject.CompareTag("EnemyAttack")) // EnemyAttackのプレハブに当たると
        {
            currentHealth--; // HPを減らす

            if (currentHealth <= 0)
            {
                Destroy(gameObject); // HPが0以下になったらオブジェクトを破壊する
            }
        }
    }
}
