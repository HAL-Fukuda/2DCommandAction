using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Command : MonoBehaviour
{
    [SerializeField] private ParticleSystem healEffect;  //�q�[����Prefab
    [SerializeField] private GameObject healSE;          //�q�[����SE
    [SerializeField] private GameObject PlayerObj;          //�v���C���[�̈ʒu
    [SerializeField] private int healVal;                   //�񕜗�

    private ParticleSystem _healInstance;
    private GameObject _healSEInstance;

    public GameObject life;
    

    void HealCommandInitialize()
    {
        
    }

    void HealCommandUpdate()
    {

    }

    public void HealEffectPlay()
    {
        //�G�t�F�N�g�̃C���X�^���X�𐶐�
        _healInstance = Instantiate(healEffect);
        //�G�t�F�N�g�̔����ʒu���v���C���[�̈ʒu�ɂ���
        _healInstance.transform.position = PlayerObj.transform.position;

        HealSoundPlay();

        //Player��HP���񕜂��鏈��
        life.GetComponent<LifeManager>().GetHeal(healVal);
        //���b�Z�[�W��\�����鏈��
    }

    public void HealSoundPlay()
    {
        _healSEInstance = Instantiate(healSE);
        _healSEInstance.transform.position = PlayerObj.transform.position;
    }
}
