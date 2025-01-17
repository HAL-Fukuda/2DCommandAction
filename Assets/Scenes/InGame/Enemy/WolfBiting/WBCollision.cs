using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WBCollision : MonoBehaviour
{
    private LifeManager lifeManager;

    public AudioClip BitingSound;

    private BoxCollider2D boxCollider;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // LifeManagerスクリプトがアタッチされているオブジェクトを取得する
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManagerコンポーネントを取得する
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();

        // Box Collider 2D コンポーネントの参照を取得する
        boxCollider = this.GetComponent<BoxCollider2D>();

        //Componentを取得
        audioSource = GetComponent<AudioSource>();

        Invoke("objDestroy", 3.5f); // 保険で3.5秒後に消えてもらう
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

    public void BitingSoundPlay()
    {
        audioSource.PlayOneShot(BitingSound);  // サウンドを鳴らす
        //Debug.Log("サウンド出てほしい");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lifeManager.GetDamage(1);
            //Debug.Log("1damage");
            //audioSource.PlayOneShot(BeatingSound);  // サウンドを鳴らす
        }
        else
        {
            //audioSource.PlayOneShot(BeatingSound);
        }

    }
}
