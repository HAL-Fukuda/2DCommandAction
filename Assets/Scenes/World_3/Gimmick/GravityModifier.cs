using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityModifier : MonoBehaviour
{
    public float gravityScale = 1f; // デフォルトの重力の強さ
    public float reducedGravityScale = 0.1f; // 範囲内の重力の強さ

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Gravity"))
        {
            // プレイヤーにかかる重力を減少させる
            Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
            rb2D.gravityScale = reducedGravityScale;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Gravity"))
        {
            // プレイヤーにかかる重力を元に戻す
            Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
            rb2D.gravityScale = gravityScale;
        }
    }
}

