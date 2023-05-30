using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamaitachiPrefab : MonoBehaviour
{
    private LifeManager lifeManager;  //LifeManagerコンポーネント
    private GameObject lifeObj;  //LifeManagerスクリプトがあるオブジェクト
    private AudioSource audio;  //
    private float timer;  //
    public AudioClip sound1;  //

    void Start()
    {
        //LifeManagerコンポーネント取得
        lifeObj = GameObject.Find("Life");
        lifeManager = lifeObj.GetComponent<LifeManager>();

        //
        audio = GetComponent<AudioSource>();
        audio.Play();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lifeManager.GetDamage(1);
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Platform"))
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Swamp"))
        {
            Destroy(this.gameObject);
        }
    }
}
