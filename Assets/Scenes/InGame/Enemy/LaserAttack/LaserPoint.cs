using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LaserPoint : MonoBehaviour
{
    private Transform target;
    private float timer;

    [SerializeField] Laser laser;

    public AudioClip chargeSE;

    void Start()
    {
        // SE再生
        AudioSource.PlayClipAtPoint(chargeSE, transform.position);
        Debug.Log("チャージ開始");

        //レーザーをオフにする
        laser.ObjectOff();

        //生成されたらタイマーを０にする
        timer = 0.0f;

        // プレイヤーをターゲットにする
        GameObject player = GameObject.Find("Player");
        target = player.transform;
    }

    void Update()
    {
        //タイマー更新
        timer += Time.deltaTime;

        //ターゲットの方向に合わせる
        if (timer <= 2.0f)
        {
            ForcusTarget();
        }

        //発射
        if (timer >= 3.0f)
        {
            Fire();
        }

        //削除
        if(timer >= 5.0f)
        {
            Destroy(this.gameObject);
        }
    }

    void ForcusTarget()
    {
        // ターゲットの位置から自分自身のオブジェクトの位置を引いて、方向ベクトルを求める。
        Vector3 direction = target.position - this.transform.position;

        // 方向ベクトルを使って、回転角度を求める。
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 回転角度を自分自身のオブジェクトに適用する。
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Fire()
    {
        laser.ObjectOn();
    }
}

