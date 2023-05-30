using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    private static LifeManager lifeManager;
    public bool oneceHit; // �P�x����������Ȃ��悤��
    public int damage = 1; // �_���[�W��
    private bool oneceFlag = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �v���C���[�ɓ���������
        if (other.gameObject.CompareTag("Player"))
        {
            // ��x����������Ȃ��悤��
            if (oneceHit)
            {
                if (oneceFlag)
                {
                    return;
                }

                oneceFlag = true;
            }

            // LifeManager�X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g���擾����
            GameObject lifeManagerObject = GameObject.Find("Life");

            // LifeManager�R���|�[�l���g���擾����
            lifeManager = lifeManagerObject.GetComponent<LifeManager>();

            // �v���C���[�Ƀ_���[�W��^����
            lifeManager.GetDamage(damage);
        }
    }
}
