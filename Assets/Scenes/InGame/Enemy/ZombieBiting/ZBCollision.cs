using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZBCollision : MonoBehaviour
{
    private LifeManager lifeManager;

    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        // LifeManagerスクリプトがアタッチされているオブジェクトを取得する
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManagerコンポーネントを取得する
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();

        // Box Collider 2D コンポーネントの参照を取得する
        boxCollider = this.GetComponent<BoxCollider2D>();

        Invoke("objDestroy", 4.0f); // 保険で4秒後に消えてもらう

    }

    private void objDestroy()
    {
        Destroy(this.gameObject);
    }

    public void ToggleCollider(bool enabled)
    {
        // Box Collider 2D コンポーネントの enabled プロパティを設定する
        boxCollider.enabled = enabled;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lifeManager.GetDamage(2);
            //Debug.Log("1damage");
            //audioSource.PlayOneShot(BeatingSound);  // サウンドを鳴らす
        }
        else
        {
            //audioSource.PlayOneShot(BeatingSound);
        }

    }
}
