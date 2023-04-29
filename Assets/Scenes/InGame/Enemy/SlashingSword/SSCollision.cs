using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSCollision : MonoBehaviour
{
    private LifeManager lifeManager;

    public AudioClip HittingSound;
    public AudioClip SwingSound;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // LifeManager�X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g���擾����
        GameObject lifeManagerObject = GameObject.Find("Life");
        // LifeManager�R���|�[�l���g���擾����
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();

        //Component���擾
        audioSource = GetComponent<AudioSource>();

    }

    public void SwingSoundPlay()
    {
        audioSource.PlayOneShot(SwingSound);  // �T�E���h��炷
        //Debug.Log("�T�E���h��");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lifeManager.GetDamage(1);
            //Debug.Log("1damage");
            audioSource.PlayOneShot(HittingSound);  // �T�E���h��炷
        }
        else
        {
            //audioSource.PlayOneShot(BeatingSound);
        }

    }
}
