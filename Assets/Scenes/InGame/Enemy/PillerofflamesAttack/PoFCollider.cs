using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoFCollider : MonoBehaviour
{
    private LifeManager lifeManager;
    // 例えばこんな感じ
    [SerializeField] private ParticleSystem explosionPrefab; // パーティクルシステムのプレハブ
    public AudioClip se;

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

            Debug.Log("dwkodkw");
            lifeManager.GetDamage(1);
            Destroy(gameObject);
            // パーティクルシステムの再生
            //ParticleSystem explosion = Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
            //AudioSource.PlayClipAtPoint(se, transform.position);
        }
    }

}
