using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Feather : MonoBehaviour
{
    private Transform target;
    private float timer;
    private bool isFired;
    private Vector3 goalPosition; // 到達座標
    private SpriteRenderer spriteRenderer;
    private LifeManager lifeManager;
    private bool oneceHit; // １度しか当たらないように
    public AudioClip windSE;
    public AudioClip spawnSE;

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

        spriteRenderer = this.GetComponent<SpriteRenderer>();

        // LifeManagerスクリプトがアタッチされているオブジェクトを取得する
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManagerコンポーネントを取得する
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // タイマー更新
        timer += Time.deltaTime;

        // 生成後2.0秒までターゲットの方向に合わせる
        if (timer <= 2.0f)
        {
            ForcusTarget();
        }

        // 生成後3.5秒経ったら発射
        if (timer >= 3.5f)
        {
            if(isFired == false) // 発射したかどうか
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

        // ターゲットの座標を到達座標として取得
        goalPosition = target.position;
    }

    // 発射
    void Fire()
    {
        // SE再生
        AudioSource.PlayClipAtPoint(windSE, transform.position);
        // 到達座標に向かって１秒で移動
        this.transform.DOMove(goalPosition, 1.0f).OnComplete(() =>
        {
            // 移動後に1秒でMaterialのアルファを0にする
            spriteRenderer.material.DOFade(0.0f, 1.0f).OnComplete(() =>
            {
                // 透明になったら削除
                Destroy(this.gameObject);
            });
        });
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (oneceHit == false)
            {
                lifeManager.GetDamage(1);
                oneceHit = true;
            }
        }
    }
}
