using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCollision : MonoBehaviour
{
    private LifeManager lifeManager;
    public AudioClip HittingSound;
    private AudioSource audioSource;


    private void Start()
    {
        // LifeManagerスクリプトがアタッチされているオブジェクトを取得する
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManagerコンポーネントを取得する
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();

        //Componentを取得
        audioSource = GetComponent<AudioSource>();

        Invoke("objDestroy", 3.5f); // 保険で3.5秒後に消えてもらう
    }

    private void objDestroy()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lifeManager.GetDamage(2);
            //Debug.Log("1damage");
            audioSource.PlayOneShot(HittingSound);  // サウンドを鳴らす
        }
        else
        {
            audioSource.PlayOneShot(HittingSound);
        }

    }
}