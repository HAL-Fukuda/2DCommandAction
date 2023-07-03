using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Yukionna : Enemy
{
    void Start()
    {
        base.Start();
        //base.EnemySoundPlay();
    }

    void Update()
    {
        if (isFadeIn)
        {
            base.FadeIn();
        }
        if (isFadeOut)
        {
            base.FadeOut();
        }
        if (killFlag)
        {
            base.DestroyEffectSpawn();
        }
        // �Q�[�W�����܂�����
        if (actionBar.GetComponent<ActionBarControl>().IsReady() && initialized == false)
        {
            attackScript.ArareAttackInitialize();
            attackScript.IceThornInitialize();
            initialized = true;
        }
    }

    public override void Attack()
    {
        PatternRandom();
        initialized = false;
        //base.EnemySoundPlay();
    }

    public override void PatternRandom()
    {
        string text;

        switch (attackNum)
        {
            case 0:
                text = "�Ꮧ�̃A�C�V�N�����C�I";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.IceThorn();
                break;
            case 1:
                text = "�Ꮧ�̃w�C���X�g�[���I";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.ArareAttack();
                break;
        }
    }

    public override void NextAttackNum()
    {
        int attackType = 0;

        attackNum = Random.Range(0, 2);

        switch (attackNum)
        {
            case 0:
                attackType = 0;
                break;
            case 1:
                attackType = 1;
                break;
        }

        //�A�^�b�N�A�C�R���������ɂ���ĕ\��
        imageSwicher.SwitchSprite(attackType);
    }
}
