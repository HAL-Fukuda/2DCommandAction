using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingCollider : MonoBehaviour
{
    private LifeManager lifeManager;
    public float speed;
    private Transform playerTransform;
    public float destroyTime;

    void Start()
    {
        // LifeManagerスクリプトがアタッチされているオブジェクトを取得する
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManagerコンポーネントを取得する
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lifeManager.GetDamage(1);
            Destroy(gameObject);
        }
    }
}
