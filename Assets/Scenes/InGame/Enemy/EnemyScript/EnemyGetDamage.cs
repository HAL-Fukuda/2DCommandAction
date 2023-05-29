using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Enemy : MonoBehaviour
{
    private Material material; // マテリアル
    private Color originalColor; // 元の色
    private Vector3 originalPosition; // 振動前の座標

    public float ColorDuration = 0.1f; // 赤くなる時間
    public float shakeIntensity = 0.1f; // 揺れの強さ
    public float shakeDuration = 0.2f; // 揺れる時間

    [SerializeField][Header("フェードイン、アウト用")]
    float fadeInSpeed = 0.01f;    //フェードインスピード
    float fadeOutSpeed = 0.01f;  //フェードアウトスピード
    float red, green, blue, alfa;  //Materialの色
    public Renderer fadeMaterial;  //Materialにアクセスするための容器
    public bool isFadeOut = false;  //フェードアウト状態の管理
    public bool isFadeIn = true;   //フェードイン状態の管理

    [SerializeField][Header("エフェクト用")]
    public bool killFlag = false;  //死亡時エフェクト用
    public bool hitFlag = false;  //ヒットエフェクト用
    [SerializeField] private GameObject hitEffectPrefab;  //ヒットエフェクト用
    [SerializeField] private GameObject destroyEffectPrefab;  //死亡時エフェクト用
    [SerializeField] private GameObject rangeAPrefab;  //エフェクト生成範囲A
    [SerializeField] private GameObject rangeBPrefab;  //エフェクト生成範囲B
    public float hitTime;  //ヒットエフェクトを生成する時間
    private float spawnTime;  //エフェクト用
    
    // 初期化処理。必ずStart()で呼び出すこと。
    public void GetDamageInitialize()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        material = renderer.material;
        originalColor = material.color;

        fadeMaterial = GetComponent<Renderer>();
        red = fadeMaterial.material.color.r;
        green = fadeMaterial.material.color.g;
        blue = fadeMaterial.material.color.b;
        alfa = fadeMaterial.material.color.a;
    }

    public void GetDamage()
    {
        GetDamageInitialize();

        // カメラを揺らす
        CameraEffect cameraScript = GameObject.Find("Main Camera").GetComponent<CameraEffect>();
        cameraScript.ShakeCamera(0.2f, 0.2f);

        // 攻撃された時の位置を取得する
        originalPosition = transform.position;

        hitFlag = true;

        // HPを1減らす
        hp--;

        // HPが0になったら削除する
        if (hp <= 0)
        {
            GameMgr.Instance.DeleteEnemy();

            isFadeOut = true;
            killFlag = true;
        }

        // 数秒後元の色に戻す
        StartCoroutine(ChangeAndResetColor(ColorDuration));
        // 振動させる
        StartCoroutine(ShakeCoroutine());
    }

    public void GetBigDamage()
    {
        GetDamageInitialize();

        // カメラを揺らす
        CameraEffect cameraScript = GameObject.Find("Main Camera").GetComponent<CameraEffect>();
        cameraScript.ShakeCamera(0.2f, 0.2f);

        // 攻撃された時の位置を取得する
        originalPosition = transform.position;

        hitFlag = true;

        // HPを1減らす
        hp -= 2;

        // HPが0になったら削除する
        if (hp <= 0)
        {
            GameMgr.Instance.DeleteEnemy();

            isFadeOut = true;
            killFlag = true;
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

    public void FadeIn()
    {
        fadeMaterial.enabled = true;
        alfa += fadeInSpeed;
        SetAlfa();
        
        if (alfa >= 1)
        {
            isFadeIn = false;
        }
    }

    public void FadeOut()
    {
        alfa -= fadeOutSpeed;
        SetAlfa();
        
        if (alfa <= 0)
        {
            isFadeOut = false;
            fadeMaterial.enabled = false;
            killFlag = false;
            GameMgr.Instance.DeathFlagChenge();

            Destroy(this.gameObject);
        }
    }

    public void SetAlfa()
    {
        fadeMaterial.material.color = new Color(red, green, blue, alfa);
    }

    public void DestroyEffectSpawn()
    {
        spawnTime = spawnTime + Time.deltaTime;

        if (spawnTime > 0.1f)
        {
            float x = Random.Range(rangeAPrefab.transform.position.x, rangeBPrefab.transform.position.x);
            float y = Random.Range(rangeAPrefab.transform.position.y, rangeBPrefab.transform.position.y);
            float z = Random.Range(rangeAPrefab.transform.position.z, rangeBPrefab.transform.position.z);

            Instantiate(destroyEffectPrefab, new Vector3(x, y, z), destroyEffectPrefab.transform.rotation);
            spawnTime = 0f;
        }
    }

    public void GetDamegeEffectSpawn()
    {
        spawnTime = spawnTime + Time.deltaTime;
        //Debug.Log("Hit");
        if (spawnTime > 0.1f)
        {
            float x = Random.Range(rangeAPrefab.transform.position.x, rangeBPrefab.transform.position.x);
            float y = Random.Range(rangeAPrefab.transform.position.y, rangeBPrefab.transform.position.y);
            float z = Random.Range(rangeAPrefab.transform.position.z, rangeBPrefab.transform.position.z);

            Instantiate(hitEffectPrefab, new Vector3(x, y, z), hitEffectPrefab.transform.rotation);
            spawnTime = 0f;
        }
    }
}
