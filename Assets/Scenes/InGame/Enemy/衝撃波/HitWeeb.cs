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
        // “§–¾‚É‚·‚é‚½‚ß‚ÉspriteRenderer‚ğæ“¾
        spriteRenderer = GetComponent<SpriteRenderer>();

        Fire(); // ”­Ë‚·‚é
    }

    void Fire()
    {
        // ƒ[ƒJƒ‹X²‚ÉŒü‚©‚Á‚Ä‚P•b‚Å10fˆÚ“®
        this.transform.DOLocalMove(this.transform.right * range * (int)direction, effectTime).SetRelative(true).OnComplete(() =>
        {
            // ˆÚ“®Œã‚É1•b‚Å“§–¾‚É‚·‚é
            spriteRenderer.material.DOFade(0.0f, 1.0f).OnComplete(() =>
            {
                // “§–¾‚É‚È‚Á‚½‚çíœ
                Destroy(this.gameObject);
            });
        });
    }
}
