using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Magma : MonoBehaviour
{

    public AudioClip se;
    void Start()
    {
        // �������[�v
        DOTween.Sequence()
              .AppendInterval(3)//�O�b��
              .Append(transform.DOMoveY(-1, 6))//-1��6�b�����Č�����
              .AppendInterval(3)//�O�b��
              .Append(transform.DOMoveY(-7, 6))//-7��6�b�����Č�����
              .SetLoops(-1);//���[�v������

        AudioSource.PlayClipAtPoint(se, transform.position);//SE
    }
}
