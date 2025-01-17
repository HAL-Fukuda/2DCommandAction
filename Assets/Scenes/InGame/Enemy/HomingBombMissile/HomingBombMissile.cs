using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HomingBombMissile : MonoBehaviour
{
    private Transform target;
    public float speed = 1.0f;
    public float lifeTime = 5.0f;

    public AudioClip windSE;
    public AudioClip spawnSE;
    public GameObject explosionPrefab; // 爆発エフェクトのプレハブ

    private float timer;
    private float maxAngle = 15; // 最大回転角度
    private SpriteRenderer spriteRenderer;
    private bool oneceHit; // １度しか当たらないように
    private Tweener tweener;

    // Start is called before the first frame update
    void Start()
    {
        // SE再生
        AudioSource.PlayClipAtPoint(spawnSE, transform.position);

        // プレイヤーをターゲットにする
        GameObject player = GameObject.Find("Player");
        target = player.transform;

        // ターゲットの方向を見る
        ForcusTarget();

        // 生成されたらタイマーリセット
        timer = 0.0f;

        // スプライトレンダラー取得
        spriteRenderer = this.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // 0.5f秒経ったらホーミング開始
        if (timer >= 3.0f) 
        {
            HomingUpdate();
        }
        
        // 生存時間を超えたら爆発
        if(timer >= lifeTime)
        {
            if(oneceHit == false)
            {
                oneceHit = true;    
                Explosion();
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

    void HomingUpdate()
    {
        // ターゲットの位置から自分自身のオブジェクトの位置を引いて、方向ベクトルを求める。
        Vector3 direction = target.position - this.transform.position;

        // 方向ベクトルを使って、回転角度を求める。
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 追尾性能えぐいから最大回転角度よりも大きくならないようにする
        // うおおおおおおおおおおおお

        // 回転角度を自分自身のオブジェクトに適用する。
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        // 移動する
        this.transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (oneceHit == false)
        {
            oneceHit = true;

            // 何かにぶつかったら爆発
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Command") || other.gameObject.CompareTag("Platform"))
            {
                Explosion();
            }
        }
    }

    void Explosion()
    {
        // 爆発エフェクト生成
        Instantiate(explosionPrefab, this.transform);

        // ミサイルを透明にする
        Color spriteColor = spriteRenderer.color;
        spriteColor.a = 0f; // アルファ値を0に設定（完全に透明）
        spriteRenderer.color = spriteColor;

        // 当たり判定を消す
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;

        // オブジェクトを削除する
        Invoke("DestroyObject", 1.5f);
    }

    // オブジェクトを削除する関数
    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}