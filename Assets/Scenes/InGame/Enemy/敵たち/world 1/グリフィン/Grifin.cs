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
    }

    public override void Attack()
    {
        //“GŒÅ—L‚ÌUŒ‚‚ğŒÄ‚Ô
        attackScript.MeteorAttack();
        //base.EnemySoundPlay();
    }
}
