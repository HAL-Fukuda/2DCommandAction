using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private LifeManager lifeManager;
    private bool oneceHit; // １度しか当たらないように

    private void Start()
    {
         // LifeManagerスクリプトがアタッチされているオブジェクトを取得する
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManagerコンポーネントを取得する
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();
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
