using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsMacineGun : MonoBehaviour
{
    private GameObject forcusPointObj;
    private Transform targetPos;

    private ParticleSystem particle;

    private AudioSource audio;
    public AudioClip bulletsSound;

    private GameObject lifeManagerObj;
    private LifeManager lifeManager;

    private float timer;

    void Start()
    {
        forcusPointObj = GameObject.FindWithTag("ForcusPoint");
        targetPos = forcusPointObj.transform;

        particle = GetComponent<ParticleSystem>();

        audio = GetComponent<AudioSource>();

        lifeManagerObj = GameObject.Find("Life");
        lifeManager = lifeManagerObj.GetComponent<LifeManager>();
    }
    
    void Update()
    {
        timer += Time.deltaTime;

        if (timer <= 1f)
        {
            ForcusTarget();
        }

        audio.Play();

        if (particle.isStopped)
        {
            Destroy(this.gameObject);
        }
    }

    // ターゲットの方向を向く
    void ForcusTarget()
    {
        // ターゲットの位置から自分自身のオブジェクトの位置を引いて、方向ベクトルを求める。
        Vector3 direction = targetPos.position - this.transform.position;

        // 方向ベクトルを使って、回転角度を求める。
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 回転角度を自分自身のオブジェクトに適用する。
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lifeManager.GetDamage(1);
        }
    }
}
