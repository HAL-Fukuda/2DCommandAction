using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Net.Sockets;

public class SideMissile : MonoBehaviour
{
    public enum eDirection
    {
        left,
        right
    }
    public eDirection direction; // 発射方向
    public float speed;
    public float lifeTime;

    public GameObject explosionPrefab; // 爆発エフェクトのプレハブ
    public AudioClip windSE;
    public AudioClip spawnSE;

    private SpriteRenderer spriteRenderer;
    private Tweener tweener;
    private float timer;
    private bool isFired;

    // Start is called before the first frame update
    void Start()
    {
        // SE再生
        AudioSource.PlayClipAtPoint(spawnSE, transform.position);

        // 発射方向に合わせて回転
        Vector3 rot = Vector3.zero;
        if (direction == eDirection.left)
        {
            rot.z = 180;
        }
        transform.rotation = Quaternion.Euler(rot);

        // 生成されたらタイマーリセット
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= 0.5f)
        {
            if (isFired == false) // 発射したかどうか
            {
                isFired = true;
                Fire();
            }
        }

        if (timer >= lifeTime)
        {
            // 生存時間が切れると爆発
            Explosion();
        }

        // 何かにぶつかると爆発
    }

    // 発射
    void Fire()
    {
        // SE再生
        AudioSource.PlayClipAtPoint(windSE, transform.position);
        // トランスフォームを取得
        Transform objectTransform = this.transform;
        // ローカルX軸に向かって移動
        tweener = this.transform.DOLocalMove(objectTransform.right * 50f, speed).SetRelative(true);
    }

    void Explosion()
    {
        // tweenを強制終了させる
        if (tweener != null)
        {
            tweener.Kill();
        }

        // 爆発エフェクト生成
        Instantiate(explosionPrefab, this.transform);

        // ミサイルを透明にする
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        Color spriteColor = spriteRenderer.color;
        spriteColor.a = 0f; // アルファ値を0に設定（完全に透明）
        spriteRenderer.color = spriteColor;

        // オブジェクトを削除する
        Invoke("DestroyObject", 0.2f);
    }

    // 1秒後にオブジェクトを削除する関数
    void DestroyObject()
    {
        Destroy(this.gameObject);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // 何かにぶつかったら爆発
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Command") || other.gameObject.CompareTag("Platform"))
        {
            Explosion();
        }
    }
}