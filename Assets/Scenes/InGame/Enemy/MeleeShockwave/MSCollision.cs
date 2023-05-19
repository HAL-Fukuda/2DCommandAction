using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSCollision : MonoBehaviour
{
    private LifeManager lifeManager;
    public GameObject Shockwave;
    //public AudioClip BeatingSound;
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
        Transform spawnPos = this.transform;

        Instantiate(Shockwave, spawnPos);

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