using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSCollision : MonoBehaviour
{
    private LifeManager lifeManager;

    public AudioClip HittingSound;
    public AudioClip SwingSound;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // LifeManagerスクリプトがアタッチされているオブジェクトを取得する
        GameObject lifeManagerObject = GameObject.Find("Life");
        // LifeManagerコンポーネントを取得する
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();

        //Componentを取得
        audioSource = GetComponent<AudioSource>();

    }

    public void SwingSoundPlay()
    {
        audioSource.PlayOneShot(SwingSound);  // サウンドを鳴らす
        //Debug.Log("サウンド鳴る");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lifeManager.GetDamage(1);
            //Debug.Log("1damage");
            audioSource.PlayOneShot(HittingSound);  // サウンドを鳴らす
        }
        else
        {
            //audioSource.PlayOneShot(BeatingSound);
        }

    }
}
