using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Enemy : MonoBehaviour
{
    // 汎用的に使える変数はここ！



    // Start is called before the first frame update
    void Start()
    {
        // GetDamage
        GetDamageInitialize();
        // EnemyAttack
        EnemyAttackInitialize();
    }

    // Update is called once per frame
    void Update()
    {
        // EnemyAttack
        if (Input.GetKey(KeyCode.E))
        {
            EnemyAttackUpdate();
        }
    }

    // 衝突時
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // タグがPunchかどうか
        if (collision.gameObject.CompareTag("Punch"))
        {
            // コマンドに攻撃が当たった時の処理を呼び出す
            GetDamage();
        }
    }
}
