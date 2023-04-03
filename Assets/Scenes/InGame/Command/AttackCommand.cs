using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Command : MonoBehaviour
{
    [SerializeField] private ParticleSystem SlashingEffect;  //�a����Prefab
    [SerializeField] private GameObject SlashingSE;      //�a����SE

    private ParticleSystem _slashInstance;
    private GameObject _slashSEInstance;

    private GameObject enemy;
    public string attackMessage = "";

    void AttackCommandInitialize()
    {

    }

    void AttackCommandUpdate()
    {

    }

    public void SlashEffectPlay()
    {
        // �G�l�~�[�̃I�u�W�F�N�g�擾
        enemy = GameObject.Find("Enemy");

        //�G�t�F�N�g�̃C���X�^���X�𐶐�
        _slashInstance = Instantiate(SlashingEffect);
        //�G�t�F�N�g�̔����ʒu��G�̈ʒu�ɂ���
        _slashInstance.transform.position = enemy.transform.position;

        SlashSoundPlay();

        //Enemy�Ƀ_���[�W��^����
        enemy.GetComponent<EnemyGetDamage>().GetDamage();

        //���b�Z�[�W��\��
        MessageWindow.Instance.SetDebugMessage(attackMessage);

    }

    //�a����SE���Đ�
    void SlashSoundPlay()
    {
        // �G�l�~�[�̃I�u�W�F�N�g�擾
        enemy = GameObject.Find("Enemy");

        _slashSEInstance = Instantiate(SlashingSE);
        _slashSEInstance.transform.position = enemy.transform.position;
    }
}
