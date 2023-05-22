using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPCollision : MonoBehaviour
{
    private LifeManager lifeManager;
    public AudioClip HittingSound;
    private AudioSource audioSource;

    private bool Hitflg = false;

    private EnemyAttack enemyAttack;





    private void Start()
    {
        // LifeManagerスクリプトがアタッチされているオブジェクトを取得する
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManagerコンポーネントを取得する
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();

        //Componentを取得
        audioSource = GetComponent<AudioSource>();

        // LifeManagerスクリプトがアタッチされているオブジェクトを取得する
        GameObject enemyManagerObject = GameObject.FindWithTag("Enemy");

        // LifeManagerコンポーネントを取得する
        enemyAttack = enemyManagerObject.GetComponent<EnemyAttack>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lifeManager.GetDamage(2);
            //Debug.Log("1damage");

            audioSource.PlayOneShot(HittingSound);  // サウンドを鳴らす

            Hitflg = true;

            // スロウになる関数
            enemyAttack.IceAge();
        }
        else
        {
            audioSource.PlayOneShot(HittingSound);
        }

    }
}
