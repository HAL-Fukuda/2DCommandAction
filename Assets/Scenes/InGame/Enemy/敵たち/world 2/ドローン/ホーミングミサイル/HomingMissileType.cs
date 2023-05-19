using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissileType : Enemy
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
            attackScript.HomingBombMissileInitialize(); // ‰H”ò‚Î‚µUŒ‚‚Ì‰Šú‰»ˆ—
            initialized = true;
        }
    }

    public override void Attack()
    {
        attackScript.HomingBombMissileAttack();
        initialized = false;
        //base.EnemySoundPlay();
    }
}
