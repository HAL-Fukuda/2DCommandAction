using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WBCollision : MonoBehaviour
{
    private LifeManager lifeManager;

    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        // LifeManager�X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g���擾����
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManager�R���|�[�l���g���擾����
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();

        // Box Collider 2D �R���|�[�l���g�̎Q�Ƃ��擾����
        boxCollider = this.GetComponent<BoxCollider2D>();

    }

    public void ToggleCollider(bool enabled)
    {
        // Box Collider 2D �R���|�[�l���g�� enabled �v���p�e�B��ݒ肷��
        boxCollider.enabled = enabled;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lifeManager.GetDamage(1);
            //Debug.Log("1damage");
            //audioSource.PlayOneShot(BeatingSound);  // �T�E���h��炷
        }
        else
        {
            //audioSource.PlayOneShot(BeatingSound);
        }

    }
}