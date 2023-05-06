using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    public AudioClip se;
    void Start()
    {
        DOTween.Sequence()
              .AppendInterval(3)//�O�b��
              .Append(transform.DOMoveY(0, 0.5f))//-1��6�b�����Č�����
              .Append(transform.DOMoveY(-5, 0.5f))//-7��6�b�����Č�����
              .SetLoops(-1);//���[�v������

        AudioSource.PlayClipAtPoint(se, transform.position);//SE

 
    }
}
