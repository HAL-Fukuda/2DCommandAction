using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime: Enemy
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
                attackScript.BindAttack();
                break;
            case 1:
                attackScript.BindAttack();
                break;
            case 2:
                attackScript.BindAttack();
                break;
            case 3:
                attackScript.BindAttack();
                break;
            case 4:
                attackScript.BindAttack();
                break;
        }
    }
}
