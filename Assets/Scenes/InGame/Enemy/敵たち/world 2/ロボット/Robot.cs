using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : Enemy
{
    //private GameObject enemyTag;

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
            attackScript.BombMissileInitialize();
            attackScript.LaserIrradiationInitialize();
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
                text = "�Ǝˎ����[�U�[���ˁI";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.LaserIrradiation();
                break;
            case 1:
                text = "�~�T�C�����ˁI";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.BombMissileAttack();
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
        spriteSwitcher.SwitchSprite(attackType);
    }
}
