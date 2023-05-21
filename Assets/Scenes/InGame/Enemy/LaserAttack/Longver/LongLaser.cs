using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongLaser : MonoBehaviour
{
    [SerializeField] LongLaserPoint longlaserPoint;
    public AudioClip FireSE;

    private LifeManager lifeManager;

    void Start()
    {
        // SE再生
        AudioSource.PlayClipAtPoint(FireSE, transform.position);

        // LifeManagerスクリプトがアタッチされているオブジェクトを取得する
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManagerコンポーネントを取得する
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();
    }

    public void ObjectOn()
    {
        gameObject.SetActive(true);
    }

    public void ObjectOff()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lifeManager.GetDamage(1);
        }
    }
}
