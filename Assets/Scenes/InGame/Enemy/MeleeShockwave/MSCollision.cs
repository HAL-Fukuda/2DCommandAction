using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSCollision : MonoBehaviour
{
    private LifeManager lifeManager;
    public GameObject Shockwave;
    //public AudioClip BeatingSound;
    //private AudioSource audioSource;


    private void Start()
    {
        // LifeManagerスクリプトがアタッチされているオブジェクトを取得する
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManagerコンポーネントを取得する
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();

        //Componentを取得
        //audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Transform spawnPos = this.transform;

        Instantiate(Shockwave, spawnPos);

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