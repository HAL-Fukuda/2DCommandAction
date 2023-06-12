using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinArcher : Enemy
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
        if (actionBar.GetComponent<ActionBarControl>().IsReady() &&
            initialized == false)
        {
            attackScript.BowAttackInitialize(); // �|��U���̏���������
            initialized = true;
        }
    }

    public override void Attack()
    {
        string text = "�S�u�����̋|��������I";
        MessageWindow.Instance.SetDebugMessage(text);
        attackScript.BowAttack();
        initialized = false;
        //base.EnemySoundPlay();
    }
}
