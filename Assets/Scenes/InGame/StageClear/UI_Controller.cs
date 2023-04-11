using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UI_Controller : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector2 position;

    public enum eDrawType
    {
        DROP,
        FADE,
    }
    public eDrawType drawType = eDrawType.DROP;
    
    // Start is called before the first frame update
    void Start()
    {
        Draw(drawType);
    }

    private void Draw(eDrawType type)
    {
        switch (type)
        {
            case eDrawType.DROP:
                Drop();
                break;
            
            case eDrawType.FADE:
                Fade();
                break;
        }
    }

    private void Drop()
    {
        // ��ʏ�ɔz�u
        this.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,700);

        // ��ʒ��S�ɗ����Ă���
        this.GetComponent<RectTransform>().DOAnchorPos(position, speed).SetEase(Ease.InQuad).OnComplete(() =>
        {
            // �������I�������P�b��ɉ�ʏ�ɖ߂�
            this.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 700), speed).SetDelay(1f).OnComplete(() =>
            {
                // �I�u�W�F�N�g�폜
                Destroy(gameObject);
            });
        });
    }

    private void Fade()
    {
        // �����x���O�ɂ���

        // ��ʒ��S�ɔz�u

        // �����x���P�ɂ���

        // �P�b�㓧���x���O�ɂ���

        // �I�u�W�F�N�g�폜
    }
}
