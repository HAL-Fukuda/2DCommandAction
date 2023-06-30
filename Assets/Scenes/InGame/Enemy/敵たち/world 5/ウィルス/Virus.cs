using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : Enemy
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
            attackScript.SporeInitialize();
            attackScript.HomingenergyInitialize();
            attackScript.HomingBombMissileInitialize();
            attackScript.ThunderboltAttackInitialize();
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
                text = "�G���o�O";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.Spore();
                break;
            case 1:
                text = "�R�[�h:�t�F�C�J�[�y�h���S���z";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.InevitableAttack();
                break;
            case 2:
                text = "�R�[�h:�t�F�C�J�[�y�{�X���{�b�g�z";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.HomingBombMissileAttack();
                break;
            case 3:
                text = "�R�[�h:�t�F�C�J�[�y�F���D�z";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.HomingenergyAttack();
                break;
            case 4:
                text = "�R�[�h:�t�F�C�J�[�y���Ձz";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.ThunderboltAttack();
                break;
        }
    }

    public override void NextAttackNum()
    {
        int attackType = 0;

        attackNum = Random.Range(0, 5);

        switch (attackNum)
        {
            case 0:
                attackType = 0;
                break;
            case 1:
                attackType = 1;
                break;
            case 2:
                attackType = 0;
                break;
            case 3:
                attackType = 0;
                break;
            case 4:
                attackType = 1;
                break;
        }

        //�A�^�b�N�A�C�R���������ɂ���ĕ\��
        spriteSwitcher.SwitchSprite(attackType);
    }
}
