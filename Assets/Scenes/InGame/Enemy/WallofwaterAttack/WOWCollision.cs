using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WOWCollision : MonoBehaviour
{
    private LifeManager lifeManager;
    public AudioClip BeatingSound;
    //private AudioSource audioSource;


    private void Start()
    {
        // LifeManager�X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g���擾����
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManager�R���|�[�l���g���擾����
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();

        //Component���擾
        //audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lifeManager.GetDamage(1);
        }
    }
}
