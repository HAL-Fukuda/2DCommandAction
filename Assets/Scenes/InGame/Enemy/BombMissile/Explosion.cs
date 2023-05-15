using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private LifeManager lifeManager;
    private bool oneceHit; // �P�x����������Ȃ��悤��

    private void Start()
    {
         // LifeManager�X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g���擾����
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManager�R���|�[�l���g���擾����
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (oneceHit == false)
            {
                lifeManager.GetDamage(1);
                oneceHit = true;
            }
        }
    }
}
