using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    private LifeManager lifeManager;
    public bool oneceHit; // �P�x����������Ȃ��悤��
    public int damage = 1; // �_���[�W��

    void Start()
    {
        // LifeManager�X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g���擾����
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManager�R���|�[�l���g���擾����
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �v���C���[�ɓ���������
        if (other.gameObject.CompareTag("Player"))
        {
            if (oneceHit)
            {
                // �����蔻�������
                BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
                boxCollider.enabled = false;
            }

            // �v���C���[�Ƀ_���[�W��^����
            lifeManager.GetDamage(damage);
        }
    }
}
