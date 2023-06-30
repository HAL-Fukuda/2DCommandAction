using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Enemy
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
                text = "�h���S���̃��e�I�I";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.MeteorAttack();
                break;
            case 1:
                text = "�h���S���̃X�[�p�[�m���@�I";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.InevitableAttack();
                break;
            case 2:
                text = "�h���S���̐؂�􂫁I";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.NailAttack();
                break;
        }
    }
    public override void NextAttackNum()
    {
        int attackType = 0;

        attackNum = Random.Range(0, 3);

        switch (attackNum)
        {
            case 0:
                attackType = 0;  //�ア�U���̎�
                break;
            case 1:
                attackType = 1;  //�����U���̎�
                break;
            case 2:
                attackType = 0;
                break;
        }

        //�A�^�b�N�A�C�R���������ɂ���ĕ\��
        spriteSwitcher.SwitchSprite(attackType);
    }
}
