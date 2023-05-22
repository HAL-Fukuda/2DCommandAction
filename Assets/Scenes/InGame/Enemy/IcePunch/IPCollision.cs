using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPCollision : MonoBehaviour
{
    private LifeManager lifeManager;
    public AudioClip HittingSound;
    private AudioSource audioSource;

    private bool Hitflg = false;

    private EnemyAttack enemyAttack;





    private void Start()
    {
        // LifeManager�X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g���擾����
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManager�R���|�[�l���g���擾����
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();

        //Component���擾
        audioSource = GetComponent<AudioSource>();

        // LifeManager�X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g���擾����
        GameObject enemyManagerObject = GameObject.FindWithTag("Enemy");

        // LifeManager�R���|�[�l���g���擾����
        enemyAttack = enemyManagerObject.GetComponent<EnemyAttack>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lifeManager.GetDamage(2);
            //Debug.Log("1damage");

            audioSource.PlayOneShot(HittingSound);  // �T�E���h��炷

            Hitflg = true;

            // �X���E�ɂȂ�֐�
            enemyAttack.IceAge();
        }
        else
        {
            audioSource.PlayOneShot(HittingSound);
        }

    }
}
