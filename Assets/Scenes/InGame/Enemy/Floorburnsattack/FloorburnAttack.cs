using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour//クラス名統一
{
    public AttackSettings floorburnSettings;
    
    // public GameObject objectPrefab; // 出現するオブジェクトのプレハブ
    public float moveSpeed = 3f; // オブジェクトの上昇速度

    public void FloorburnAttack()
    {
        Vector3 spawnPosition = new Vector3(0f, -12f, 0f); // 出現位置の設定

        // オブジェクトを生成する
        GameObject newObject = Instantiate(floorburnSettings.Prefab, spawnPosition, Quaternion.identity);

        // 上方向に移動させる
        Rigidbody2D rb2D = newObject.GetComponent<Rigidbody2D>();
        if (rb2D != null)
        {
            rb2D.velocity = Vector2.up * moveSpeed;
        }
        else
        {
            Debug.LogWarning("Rigidbody2D component not found on the spawned object.");
        }
    }
}
