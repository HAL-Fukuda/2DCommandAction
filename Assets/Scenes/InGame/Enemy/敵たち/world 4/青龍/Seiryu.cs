using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seiryu : Enemy
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
        if (actionBar.GetComponent<ActionBarControl>().IsReady() &&�@initialized == false)
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
                text = "���̌����I";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.TorrentAttack();
                break;
            case 1:
                text = "���̐��ǁI";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.WofwaterAttack();
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
                attackType = 1;
                break;
            case 1:
                attackType = 0;
                break;
        }

        //�A�^�b�N�A�C�R���������ɂ���ĕ\��
        spriteSwitcher.SwitchSprite(attackType);
    }
}
