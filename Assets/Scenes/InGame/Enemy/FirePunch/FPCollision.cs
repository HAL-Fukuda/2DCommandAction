using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCollision : MonoBehaviour
{
    private LifeManager lifeManager;
    public AudioClip HittingSound;
    private AudioSource audioSource;


    private void Start()
    {
        // LifeManager�X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g���擾����
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManager�R���|�[�l���g���擾����
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();

        //Component���擾
        audioSource = GetComponent<AudioSource>();

        Invoke("objDestroy", 3.5f); // �ی���3.5�b��ɏ����Ă��炤
    }

    private void objDestroy()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lifeManager.GetDamage(2);
            //Debug.Log("1damage");
            audioSource.PlayOneShot(HittingSound);  // �T�E���h��炷
        }
        else
        {
            audioSource.PlayOneShot(HittingSound);
        }

    }
}