using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaStickyCollider : MonoBehaviour
{
    public float speed = 10f; // 敵の移動速度
    public float damageDuration = 2f; // プレイヤーがダメージを受ける時間
    public GameObject floorprefab;

    private Transform playerTransform;
    private LifeManager lifeManager;
    private bool isHit = false; // プレイヤーに当たったかどうかのフラグ
    private bool isGrounded = false; // 地面に当たったかどうかのフラグ
    private Vector3 direction; // プレイヤーの方向ベクトル

    void Start()
    {
        // LifeManagerスクリプトがアタッチされているオブジェクトを取得する
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManagerコンポーネントを取得する
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // プレイヤーの方向ベクトルを計算する
        direction = (playerTransform.position - transform.position).normalized;
    }

    void Update()
    {
        // プレイヤーの方向に一定速度で移動する
        transform.position += direction * speed * Time.deltaTime;

        if (isGrounded)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // プレイヤーに当たった場合
            lifeManager.GetDamage(1);
            isHit = true;
            Invoke("ResetHit", damageDuration); // 操作不能時間後に操作可能に戻す
        }
        else if (collision.gameObject.CompareTag("Platform"))
        {
            // 地面に当たった場合
            isGrounded = true;
            Vector3 contactPoint = collision.ClosestPoint(transform.position);
            // 地面にオブジェクトを生成し、当たった位置に置く
            GameObject obstacle = Instantiate(floorprefab, contactPoint, Quaternion.identity) as GameObject;
            //Destroy(obstacle, 5f); // 5秒後にオブジェクトを削除する
        }
    }
}