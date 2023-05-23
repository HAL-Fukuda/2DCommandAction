using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CACollision : MonoBehaviour
{
    private LifeManager lifeManager;

    private void Start()
    {
        // LifeManagerスクリプトがアタッチされているオブジェクトを取得する
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManagerコンポーネントを取得する
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lifeManager.GetDamage(3);
            //Destroy(gameObject);
            //Debug.Log("入った");
        }
    }

}
