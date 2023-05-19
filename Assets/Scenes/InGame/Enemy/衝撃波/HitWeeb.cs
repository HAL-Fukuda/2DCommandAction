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
        // �����ɂ��邽�߂�spriteRenderer���擾
        spriteRenderer = GetComponent<SpriteRenderer>();

        Fire(); // ���˂���
    }

    void Fire()
    {
        // ���[�J��X���Ɍ������ĂP�b��10f�ړ�
        this.transform.DOLocalMove(this.transform.right * range * (int)direction, effectTime).SetRelative(true).OnComplete(() =>
        {
            // �ړ����1�b�œ����ɂ���
            spriteRenderer.material.DOFade(0.0f, 1.0f).OnComplete(() =>
            {
                // �����ɂȂ�����폜
                Destroy(this.gameObject);
            });
        });
    }
}
