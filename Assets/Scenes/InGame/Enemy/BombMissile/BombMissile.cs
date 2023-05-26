using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BombMissile : MonoBehaviour
{
    private Transform target;
    private float timer;
    private bool isFired;
    private SpriteRenderer spriteRenderer;
    private bool oneceHit; // １度しか当たらないように
    public AudioClip windSE;
    public AudioClip spawnSE;
    public GameObject explosionPrefab; // 爆発エフェクトのプレハブ
    private Tweener tweener;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        // SE再生
        AudioSource.PlayClipAtPoint(spawnSE, transform.position);

        // プレイヤーをターゲットにする
        GameObject player = GameObject.Find("Player");
        target = player.transform;

        // 生成されたらタイマーリセット
        timer = 0.0f;

        //spriteRenderer = this.GetComponent<SpriteRenderer>();

        ForcusTarget();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer>= 0.5f)
        {
            if (isFired == false) // 発射したかどうか
            {
                isFired = true;
                Fire();
            }
        }
    }

    // ターゲットの方向を向く
    void ForcusTarget()
    {
        // ターゲットの位置から自分自身のオブジェクトの位置を引いて、方向ベクトルを求める。
        Vector3 direction = target.position - this.transform.position;

        // 方向ベクトルを使って、回転角度を求める。
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 回転角度を自分自身のオブジェクトに適用する。
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    // 発射
    void Fire()
    {
        // SE再生
        AudioSource.PlayClipAtPoint(windSE, transform.position);
        // トランスフォームを取得
        Transform objectTransform = this.transform;
        // ローカルX軸に向かって１秒で10f移動
        tweener = this.transform.DOLocalMove(objectTransform.right * 10f, speed).SetRelative(true).OnComplete(() =>
        {
            // 移動後に1秒でMaterialのアルファを0にする
            tweener = spriteRenderer.material.DOFade(0.0f, 1.0f).OnComplete(() =>
            {
                // 透明になったら削除
                Destroy(this.gameObject);
            });
        });
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (oneceHit == false)
        {
            oneceHit = true;

            // 何かにぶつかったら爆発
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Command") || other.gameObject.CompareTag("Platform"))
            {
                // tweenを強制終了させる
                tweener.Kill();

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
        }
    }

    // 1秒後にオブジェクトを削除する関数
    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}