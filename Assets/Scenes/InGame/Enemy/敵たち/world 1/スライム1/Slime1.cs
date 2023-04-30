using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime1: Enemy
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
    }

    public override void Attack()
    {
        //�G�ŗL�̍U�����Ă�
        attackScript.BindAttack();
        //base.EnemySoundPlay();
    }
}
