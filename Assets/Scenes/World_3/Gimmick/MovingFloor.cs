using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour
{
    [SerializeField] private float speed = 1f; // 移動速度
    [SerializeField] private float distance = 2f; // 移動距離

    private Vector3 originalPosition; // 床の初期位置
    private Vector3 targetPosition; // 床の目標位置
    private int direction = 1; // 移動方向（1:右、-1:左）

    private List<Collider2D> colliders = new List<Collider2D>(); // 床の上に乗っているオブジェクトのリスト

    private void Start()
    {
        originalPosition = transform.position;
        targetPosition = originalPosition + new Vector3(distance * direction, 0f, 0f);
    }

    private void FixedUpdate()
    {
        // 床を移動する
        transform.position += new Vector3(speed * Time.fixedDeltaTime * direction, 0f, 0f);

        // 目標位置に到達したら移動方向を反転する
        if ((transform.position - targetPosition).sqrMagnitude < 0.001f)
        {
            direction *= -1;
            targetPosition = originalPosition + new Vector3(distance * direction, 0f, 0f);
        }

        // 床の上に乗っているオブジェクトを移動させる
        foreach (Collider2D collider in colliders)
        {
            if (collider != null && collider.gameObject != null)
            {
                collider.gameObject.transform.position += new Vector3(speed * Time.fixedDeltaTime * direction, 0f, 0f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 床の上にオブジェクトが乗ったときにリストに追加する
        if (other.gameObject.CompareTag("Player"))
        {
            colliders.Add(other);
            Debug.Log("乗った");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // 床からオブジェクトが離れたときにリストから削除する
        if (other.gameObject.CompareTag("Player"))
        {
            colliders.Remove(other);
            Debug.Log("降りた");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 床の上にオブジェクトが乗ったときにリストに追加する
        if (collision.gameObject.CompareTag("Command"))
        {
            colliders.Add(collision.collider);
            Debug.Log("コマンド乗った");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // 床からオブジェクトが離れたときにリストから削除する
        if (collision.gameObject.CompareTag("Command"))
        {
            colliders.Remove(collision.collider);
            Debug.Log("降りた");
        }
    }
}
