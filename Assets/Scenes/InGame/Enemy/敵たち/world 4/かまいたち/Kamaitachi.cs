using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamaitachi : Enemy
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
            attackScript.KamaitachiAttackInitialize();
            initialized = true;
        }
    }

    public override void Attack()
    {
        //�U�����Ă�
        attackScript.KamaitachiAttack();
        initialized = false;
        //base.EnemySoundPlay();
    }
}
