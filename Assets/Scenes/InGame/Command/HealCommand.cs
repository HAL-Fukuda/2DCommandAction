using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Command : MonoBehaviour
{
    [SerializeField] private ParticleSystem healEffect; //�q�[����Prefab
    [SerializeField] private GameObject healSE;         //�q�[����SE
    [SerializeField] private int healVal;               //�񕜗�

    private GameObject PlayerObj; //�v���C���[�̈ʒu
    private ParticleSystem _healInstance;
    private GameObject _healSEInstance;

    private GameObject life;
    public string healMessage = "";
    

    void HealCommandInitialize()
    {
        PlayerObj = GameObject.Find("Player");
        life = GameObject.Find("Life");
    }

    void HealCommandUpdate()
    {

    }

    public void HealEffectPlay()
    {
        HealCommandInitialize();

        //�G�t�F�N�g�̃C���X�^���X�𐶐�
        _healInstance = Instantiate(healEffect);
        //�G�t�F�N�g�̔����ʒu���v���C���[�̈ʒu�ɂ���
        _healInstance.transform.position = PlayerObj.transform.position;

        HealSoundPlay();

        //Player��HP���񕜂��鏈��
        life.GetComponent<LifeManager>().GetHeal(healVal);
        //���b�Z�[�W��\�����鏈��
        MessageWindow.Instance.SetDebugMessage(healMessage);
    }

    void HealSoundPlay()
    {
        _healSEInstance = Instantiate(healSE);
        _healSEInstance.transform.position = PlayerObj.transform.position;
    }
}
