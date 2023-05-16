using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormat : Enemy
{

    void Start()
    {
        base.Start();
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
        //Debug.Log(attackNum);
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
                attackScript.InevitableAttack();
                break;
            case 2:
                attackScript.NailAttack();
                break;
        }
    }

    public override void NextAttackNum()
    {
        attackNum = Random.Range(0, 3);
    }
}
