using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusFormRed : Enemy
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
        // ゲージがたまったら
        if (actionBar.GetComponent<ActionBarControl>().IsReady() && initialized == false)
        {
            initialized = true;
        }
    }

    public override void Attack()
    {
        //攻撃を呼ぶ
        attackScript.MeteorAttack();
        initialized = false;
        //base.EnemySoundPlay();
    }
}
