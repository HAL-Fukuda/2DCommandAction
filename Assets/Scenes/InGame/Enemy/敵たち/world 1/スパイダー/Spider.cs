using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
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
                text = "�����̓Őj�I";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.SpiderNeedle();
                break;
        }
    }

    public override void NextAttackNum()
    {
        int attackType = 0;

        attackNum = 0;

        //�A�^�b�N�A�C�R���������ɂ���ĕ\��
        imageSwicher.SwitchSprite(attackType);
    }
}
