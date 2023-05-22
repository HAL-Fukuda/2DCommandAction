using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunderbolt : MonoBehaviour
{
    [SerializeField]
    GameObject explosion;
    float timer;
    bool oneceFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.1f) // 雷エフェクトを透明にする
        {
            if (oneceFlag == false)
            {
                oneceFlag = true;

                // 子要素を取得
                Transform colliderObject = this.transform.Find("thunderCollider");
                // 透明にする
                SpriteRenderer spriteRenderer = colliderObject.GetComponent<SpriteRenderer>();
                Color spriteColor = spriteRenderer.color;
                spriteColor.a = 0f; // アルファ値を0に設定（完全に透明）
                spriteRenderer.color = spriteColor;
                // 当たり判定を消す
                BoxCollider2D boxCollider = colliderObject.GetComponent<BoxCollider2D>();
                boxCollider.enabled = false;

                // 着弾エフェクト生成
                Vector3 spawn = transform.position + new Vector3(0, 2.25f, 0);
                Instantiate(explosion, spawn, Quaternion.identity);
            }
        }

        if (timer > 3.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
