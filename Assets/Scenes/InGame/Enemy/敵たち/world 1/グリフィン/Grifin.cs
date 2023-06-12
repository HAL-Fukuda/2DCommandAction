using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grifin : Enemy
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
        if(actionBar.GetComponent<ActionBarControl>().IsReady() &&
            initialized == false){
            attackScript.FeatherAttackInitialize(); // �H��΂��U���̏���������
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
                text = "�O���t�B���̂͂˂Ƃ΂��I";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.FeatherAttack();
                break;
            case 1:
                text = "�O���t�B���̂킵�Â��݁I";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.GrabbingAttack();
                break;
        }
    }

    public override void NextAttackNum()
    {
        //attackNum = 1;
        attackNum = Random.Range(0, 2);
    }
}
