using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    private static Tweener shakeTweener;
    private Vector3 initPosition;

    private void Start()
    {
        // �����ʒu��ێ�
        initPosition = transform.position;
    }

    /// <summary>
    /// �h��J�n
    /// </summary>
    /// <param name="duration">����</param>
    /// <param name="strength">�h��̋���</param>
    /// <param name="vibrato">�ǂ̂��炢�U�����邩</param>
    /// <param name="randomness">�����_���x��(0?180)</param>
    /// <param name="fadeOut">�t�F�[�h�A�E�g���邩</param>
    public void StartShake()
    {
        // �O��̏������c���Ă���Β�~���ď����ʒu�ɖ߂�
        if (shakeTweener != null)
        {
            shakeTweener.Kill();
            gameObject.transform.position = initPosition;
        }
        // �h��J�n
        // �������̂܂܂˂�����ł邯�ǈӖ��̓R�����g�̏ォ��Q�Ƃ���
        shakeTweener = gameObject.transform.DOShakePosition(2.0f, 0.1f, 30, 90.0f, false).OnComplete(() =>
        {
            IsReadyOn();
        });
    }
}