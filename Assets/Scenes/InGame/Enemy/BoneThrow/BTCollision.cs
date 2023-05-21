using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTCollision : MonoBehaviour
{
    private LifeManager lifeManager;

    private void Start()
    {
        // LifeManagerスクリプトがアタッチされているオブジェクトを取得する
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManagerコンポーネントを取得する
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();
    }

    private void FixedUpdate()
    {
        //時間あったら追尾機能
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lifeManager.GetDamage(2);
            //Debug.Log("1damage");
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
}
