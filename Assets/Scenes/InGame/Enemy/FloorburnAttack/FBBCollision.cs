using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBBCollision : MonoBehaviour
{
    private LifeManager lifeManager;

    private BoxCollider2D boxCollider;

    public AudioClip se;
    // Start is called before the first frame update
    void Start()
    {
        // LifeManagerスクリプトがアタッチされているオブジェクトを取得する
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManagerコンポーネントを取得する
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();

        // Box Collider 2D コンポーネントの参照を取得する
        boxCollider = this.GetComponent<BoxCollider2D>();

    }

    public void ToggleCollider(bool enabled)
    {
        // Box Collider 2D コンポーネントの enabled プロパティを設定する
        boxCollider.enabled = enabled;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lifeManager.GetDamage(1);
            //Debug.Log("1damage");
            AudioSource.PlayClipAtPoint(se, transform.position);
        }
       

    }

}
