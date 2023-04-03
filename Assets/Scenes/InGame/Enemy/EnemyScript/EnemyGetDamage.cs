using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGetDamage : MonoBehaviour
{
    private Material material; // マテリアル
    private Color originalColor; // 元の色

    public float ColorDuration = 0.1f; // 赤くなる時間

    private Vector3 originalPosition; // 振動前の座標

    public float shakeIntensity = 0.1f; // 揺れの強さ
    public float shakeDuration = 0.2f; // 揺れる時間

    private int hp = 3; // HPの初期値

    // 初期化処理。必ずStart()で呼び出すこと。
    public void GetDamageInitialize()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        material = renderer.material;
        originalColor = material.color;
    }

    public void GetDamage()
    {
        GetDamageInitialize();

        // 攻撃された時の位置を取得する
        originalPosition = transform.position;

        // HPを1減らす
        hp--;

        // HPが0になったら削除する
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

        // 数秒後元の色に戻す
        StartCoroutine(ChangeAndResetColor(ColorDuration));
        // 振動させる
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ChangeAndResetColor(float delay)
    {
        // 赤色にする
        ChangeColor(Color.red);
        // 一定時間後に色を戻す
        yield return new WaitForSeconds(delay);
        ResetColor();
    }

    public void ChangeColor(Color newColor)
    {
        material.color = newColor;
    }

    public void ResetColor()
    {
        material.color = originalColor;
    }

    // 振動
    private IEnumerator ShakeCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            // 左右にランダムに揺らす
            Vector3 shakeAmount = new Vector3(Random.Range(-1f, 1f) * shakeIntensity, 0f, 0f);
            transform.position = originalPosition + shakeAmount;

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // 元の位置に戻す
        transform.position = originalPosition;
    }
}
