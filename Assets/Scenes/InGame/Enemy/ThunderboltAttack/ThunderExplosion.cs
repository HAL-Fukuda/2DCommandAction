using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderExplosion : MonoBehaviour
{
    float timer;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;

        // スプライトレンダラー取得
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 0.3f)
        {
            // 透明にする
            Color spriteColor = spriteRenderer.color;
            spriteColor.a = 0f; // アルファ値を0に設定（完全に透明）
            spriteRenderer.color = spriteColor;
        }

        if(timer > 5.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
