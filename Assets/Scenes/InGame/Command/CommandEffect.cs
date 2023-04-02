using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Command : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] private ParticleSystem EffectPrefab;  //Effect��Prefab��ݒ�
    [SerializeField] private GameObject     SoundPrefab;   //Sound��Prefab��ݒ�

    private ParticleSystem _effectInstance;
    private GameObject _soundInstance;

    public int commandHP;  //�R�}���h��HP
   
    void CommandEffectInitialize()
    {
        rb2d = this.GetComponent<Rigidbody2D>();  //�Փˎ��ɃI�u�W�F�N�g�������ۂɎg�p
    }
    
    void CommandEffectUpdate()
    {
       
    }

    //Player�^�O���t�����I�u�W�F�N�g�����񐔓���������R�}���h������
    private void CommandEffectOnCollisionEnter(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("HIT");
            commandHP -= 1;  //�R�}���h��HP����
            Debug.Log(commandHP);

            if (commandHP <= 0)
            {
                EffectPlay();  //Effect�Đ�
                Destroy(gameObject);  //�R�}���h���폜
            }

        }
    }

    //�R�}���h��HP����������
    void CommandHit()  
    {
        commandHP -= 1;  //�R�}���h��HP����
        //Debug.Log(commandHP);

        if (commandHP <= 0)
        {
            EffectPlay();  //Effect�Đ�
            Destroy(gameObject);  //�R�}���h���폜
        }
    }

    //�G�t�F�N�g�Đ�
    void EffectPlay()  
    {
        //ParticleSystem�̃C���X�^���X�𐶐�
        _effectInstance = Instantiate(EffectPrefab);
        //Effect�̔����ʒu���R�}���h�̈ʒu�ɂ���
        _effectInstance.transform.position = this.transform.position;
        //Effect���Đ�
        _effectInstance.Play();

        //SE���Đ�
        SoundPlay();
    }

    //SE�Đ�
    void SoundPlay()  
    {
        //Sound�̃C���X�^���X�𐶐�
        _soundInstance = Instantiate(SoundPrefab);
        //Sound�̔����ʒu���R�}���h�̈ʒu�ɂ���
        _soundInstance.transform.position = this.transform.position;
        //Sound�͔����Ɠ����ɖ�悤�ɂ��Ă���
    }
}