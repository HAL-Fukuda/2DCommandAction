using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCollider : MonoBehaviour
{
    private LifeManager lifeManager;

    private void Start()
    {
        // LifeManagerスクリプトがアタッチされているオブジェクトを取得する
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManagerコンポーネントを取得する
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("dwkodkw");
            lifeManager.GetDamage(1);
            Destroy(gameObject);
        }
    }
}
