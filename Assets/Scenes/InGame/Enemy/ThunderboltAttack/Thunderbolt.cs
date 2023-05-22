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
            // 子オブジェクト取得
            Transform thunder = transform.Find("thunder");
            // スプライトレンダラー取得
            SpriteRenderer spriteRenderer = thunder.GetComponent<SpriteRenderer>();
            // 透明にする
            Color spriteColor = spriteRenderer.color;
            spriteColor.a = 0f; // アルファ値を0に設定（完全に透明）
            spriteRenderer.color = spriteColor;

            if (oneceFlag == false)
            {
                oneceFlag = true;
                Vector3 spawn = transform.position + new Vector3(0, 2.25f, 0);
                // 着弾エフェクト生成
                Instantiate(explosion, spawn, Quaternion.identity);
            }
        }

        if (timer > 3.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
