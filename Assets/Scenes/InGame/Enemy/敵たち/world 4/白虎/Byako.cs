using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Byako : Enemy
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
            attackScript.ThunderboltAttackInitialize();
            initialized = true;
        }
    }

    public override void Attack()
    {
        Debug.Log(attackNum);
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
                text = "���Ղ̉E�ܗ�I";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.ClawAttackRight();
                break;
            case 1:
                text = "���Ղ̗����I";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.ThunderboltAttack();
                break;
            case 2:
                text = "���Ղ̍��ܗ�I";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.ClawAttackLeft();
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
                attackType = 0;
                break;
            case 1:
                attackType = 1;
                break;
            case 2:
                attackType = 0;
                break;
        }

        //�A�^�b�N�A�C�R���������ɂ���ĕ\��
        imageSwicher.SwitchSprite(attackType);
    }
}
