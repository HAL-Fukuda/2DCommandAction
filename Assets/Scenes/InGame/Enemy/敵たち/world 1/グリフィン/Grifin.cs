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

        // ƒQ[ƒW‚ª‚½‚Ü‚Á‚½‚ç
        if(actionBar.GetComponent<ActionBarControl>().IsReady() &&
            initialized == false){
            attackScript.FeatherAttackInitialize(); // ‰H”ò‚Î‚µUŒ‚‚Ì‰Šú‰»ˆ—
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
                attackScript.FeatherAttack();
                break;
            case 1:
                attackScript.GrabbingAttack();
                break;
        }
    }

    public override void NextAttackNum()
    {
        attackNum = Random.Range(0, 2);
    }
}
