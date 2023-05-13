using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusForm : Enemy
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
    }

    public override void Attack()
    {
        //“GŒÅ—L‚ÌUŒ‚‚ğŒÄ‚Ô
        //attackScript.FeatherAttack();
        //base.EnemySoundPlay();
    }
}
