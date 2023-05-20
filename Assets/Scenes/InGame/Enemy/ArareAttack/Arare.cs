using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arare : MonoBehaviour
{
    private GameObject playerObj;
    private Transform target;
    private ParticleSystem particle;
    private LifeManager lifeManager;
    private bool onceHit;
    private float timer;
    

    void Start()
    {
        //SE再生
        //プレイヤーの位置を取得
        playerObj = GameObject.FindWithTag("Player");
        target = playerObj.transform;
        //パーティクルシステムを取得(再生が終わったか判定する用）
        particle = GetComponent<ParticleSystem>();
        //ライフマネージャースクリプトを取得
        GameObject LifeManagerObj = GameObject.Find("Life");
        lifeManager = LifeManagerObj.GetComponent<LifeManager>();
    }
    
    void Update()
    {
        timer += Time.deltaTime;

        //生成後2.0秒までターゲットの方向に合わせる
        if (timer <= 2.0f)
        {
            ForcusTarget();
        }

        //再生が終わったら削除
        if (particle.isStopped)
        {
            Destroy(this.gameObject);
        }
    }

    // ターゲットの方向を向く
    void ForcusTarget()
    {
        // ターゲットの位置から自分自身のオブジェクトの位置を引いて、方向ベクトルを求める。
        Vector3 direction = target.position - this.transform.position;

        // 方向ベクトルを使って、回転角度を求める。
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 回転角度を自分自身のオブジェクトに適用する。
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (onceHit == false)
            {
                lifeManager.GetDamage(1);
                onceHit = true;
            }
        }
    }

    void ParticlePlay()
    {
        if (particle)
        {
            particle.Play();
        }
    }
}
