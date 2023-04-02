using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Command : MonoBehaviour
{
    [SerializeField] private ParticleSystem SlashingEffect;  //�a����Prefab
    [SerializeField] private GameObject SlashingSE;      //�a����SE
    [SerializeField] private GameObject TargetObj;       //�G�̈ʒu

    private ParticleSystem _slashInstance;
    private GameObject _slashSEInstance;
    public GameObject enemy;

    void AttackCommandInitialize()
    {

    }

    void AttackCommandUpdate()
    {

    }

    void SlashEffectPlay()
    {
        //�G�t�F�N�g�̃C���X�^���X�𐶐�
        _slashInstance = Instantiate(SlashingEffect);
        //�G�t�F�N�g�̔����ʒu��G�̈ʒu�ɂ���
        _slashInstance.transform.position = TargetObj.transform.position;

        SlashSoundPlay();

        //Enemy�Ƀ_���[�W��^����
        enemy.GetComponent<EnemyGetDamage>().GetDamage();
        //���b�Z�[�W��\��
    }

    //�a����SE���Đ�
    void SlashSoundPlay()
    {
        _slashSEInstance = Instantiate(SlashingSE);
        _slashSEInstance.transform.position = TargetObj.transform.position;
    }
}
