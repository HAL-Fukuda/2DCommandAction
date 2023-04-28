using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grifin : Enemy
{
    void Start()
    {
        base.Start();
        base.EnemySoundPlay();
    }
    
    void Update()
    {
        if (isFadeIn)
        {
            base.FadeIn();
        }
    }

    public override void Attack()
    {
        //“GŒÅ—L‚ÌUŒ‚‚ğŒÄ‚Ô
        base.EnemySoundPlay();
    }
}
