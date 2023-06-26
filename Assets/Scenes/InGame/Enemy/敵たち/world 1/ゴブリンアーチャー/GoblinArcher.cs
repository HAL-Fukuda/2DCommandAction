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

        // ƒQ[ƒW‚ª‚½‚Ü‚Á‚½‚ç
        if (actionBar.GetComponent<ActionBarControl>().IsReady() &&
            initialized == false)
        {
            attackScript.BowAttackInitialize(); // ‹|–îUŒ‚‚Ì‰Šú‰»ˆ—
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

        switch(attackNum)
        {
            case 0:
                text = "ƒSƒuƒŠƒ“‚Ì‹|–î‚±‚¤‚°‚«I";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.BowAttack();
                break;
        }
    }

    public override void NextAttackNum()
    {
        attackNum = 0;
    }
}
