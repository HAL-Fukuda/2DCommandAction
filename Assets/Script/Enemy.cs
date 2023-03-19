using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetDamageInitialize();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void Hitcheck()
    {
        Debug.Log("敵にあたっている");
    }
}
