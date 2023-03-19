using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour //クラス名統一
{
    public GameObject prefab;  // 生成するオブジェクト
    [SerializeField][Header("生成間隔")] public float spawnInterval = 2f;  // 生成する間隔
    public float minSpeed = 2f;  // 落下する最小速度
    public float maxSpeed = 4f;  // 落下する最大速度
    public float lifeTime = 5f;  // オブジェクトの寿命
    private float timer = 0f;

    public void MeteorAttack()
    {

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;

            // 画面外にオブジェクトを生成する
            Vector3 spawnPos = new Vector3(Random.Range(-10f, 10f), 7f, 0f);//Random.Range(-10f, 10f), 7f, 0f
            GameObject obj = Instantiate(prefab, spawnPos, Quaternion.identity);

            // Rigidbody2Dコンポーネントをアタッチする
            Rigidbody2D rb2d = obj.AddComponent<Rigidbody2D>();

            // 落下速度をランダムに設定する
            float speed = Random.Range(minSpeed, maxSpeed);
            rb2d.gravityScale = speed;

            // 落下する方向をランダムに設定する
            Vector2 velocity = new Vector2(Random.Range(-1f, 1f), -1f).normalized * speed;
            rb2d.velocity = velocity;

            // 一定時間後にオブジェクトを削除する
            Destroy(obj, lifeTime);
        }
    }
}
