using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HitWeeb : MonoBehaviour
{
    [SerializeField]
    float range;
    [SerializeField]
    float effectTime;

    enum eDirection
    {
        right = 1,
        left = -1,
    }
    [SerializeField]
    eDirection direction;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // 透明にするためにspriteRendererを取得
        spriteRenderer = GetComponent<SpriteRenderer>();

        Fire(); // 発射する
    }

    void Fire()
    {
        // ローカルX軸に向かって１秒で10f移動
        this.transform.DOLocalMove(this.transform.right * range * (int)direction, effectTime).SetRelative(true).OnComplete(() =>
        {
            // 移動後に1秒で透明にする
            spriteRenderer.material.DOFade(0.0f, 1.0f).OnComplete(() =>
            {
                // 透明になったら削除
                Destroy(this.gameObject);
            });
        });
    }
}
