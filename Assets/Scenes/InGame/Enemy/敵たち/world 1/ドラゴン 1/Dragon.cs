using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Enemy
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
        PatternRandom();
        initialized = false;
        //base.EnemySoundPlay();
    }

    public override void PatternRandom()
    {
        switch (attackNum)
        {
            case 0:
                attackScript.MeteorAttack();
                break;
            case 1:
                attackScript.MeteorAttack();
                //attackScript.SideVanishAttack();
                break;
            case 2:
                attackScript.MeteorAttack();
                //attackScript.NailAttack();
                break;
            case 3:
                attackScript.MeteorAttack();
                //つかみ攻撃
                break;
            case 4:
                //
                break;
        }
    }
}
