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
        // ÉQÅ[ÉWÇ™ÇΩÇ‹Ç¡ÇΩÇÁ
        if (actionBar.GetComponent<ActionBarControl>().IsReady() &&Å@initialized == false)
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
        switch (attackNum)
        {
            case 0:
                attackScript.ThunderboltAttack();
                break;
            case 1:
                attackScript.ClawAttackRight();
                break;
            case 2:
                attackScript.ClawAttackLeft();
                break;
        }
    }

    public override void NextAttackNum()
    {
        attackNum = 2;
        //attackNum = Random.Range(0, 3);
    }
}
