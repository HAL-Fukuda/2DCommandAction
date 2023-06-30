using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCollider : MonoBehaviour
{
    private LifeManager lifeManager;
    // �Ⴆ�΂���Ȋ���
    [SerializeField] private ParticleSystem explosionPrefab; // �p�[�e�B�N���V�X�e���̃v���n�u
    public AudioClip se;

    private void Start()
    {
        // LifeManager�X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g���擾����
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManager�R���|�[�l���g���擾����
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lifeManager.GetDamage(1);
            Destroy(gameObject);
            // �p�[�e�B�N���V�X�e���̍Đ�
            ParticleSystem explosion = Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(se, transform.position);
        }

        if (collision.gameObject.CompareTag("Platform"))
        {

            Destroy(gameObject);
            ParticleSystem explosion = Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(se, transform.position);
        }
    }
}
