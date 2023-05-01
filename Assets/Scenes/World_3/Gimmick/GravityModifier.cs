using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityModifier : MonoBehaviour
{
    public float gravityScale = 1f; // �f�t�H���g�̏d�͂̋���
    public float reducedGravityScale = 0.1f; // �͈͓��̏d�͂̋���

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Gravity"))
        {
            // �v���C���[�ɂ�����d�͂�����������
            Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
            rb2D.gravityScale = reducedGravityScale;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Gravity"))
        {
            // �v���C���[�ɂ�����d�͂����ɖ߂�
            Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
            rb2D.gravityScale = gravityScale;
        }
    }
}

