using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour
{
    public GameObject homingPrefab; // 敵のプレハブ
    public Transform player; // プレイヤーのTransform

    // 指定した数だけ敵を生成する関数
    public void SpawnEnemies(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector2 spawnPosition = Random.insideUnitCircle * 10f; // 敵の出現位置をランダムに決定
            GameObject enemy = Instantiate(homingPrefab, transform.position, Quaternion.identity); // 敵を生成
            //enemy.GetComponent<EnemyAttack>().SetTarget(player); // 生成された敵がプレイヤーを追いかけるように設定
        }
    }
    //-----------------------------------
    //public float speed = 5f; // 敵の移動速度
    //private Transform target; // 追いかける対象

    //public void SetTarget(Transform target)
    //{
    //    this.target = target;
    //}

    //void Update()
    //{
    //    if (target != null)
    //    {
    //        Vector2 direction = (target.position - transform.position).normalized; // 対象に向かう方向を計算
    //        transform.position += (Vector3)direction * speed * Time.deltaTime; // 方向に沿って移動
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    // 衝突したオブジェクトがPlayerタグを持っている場合、自身を破壊する
    //    if (other.CompareTag("Player"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
