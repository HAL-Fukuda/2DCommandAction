using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magmagolem : Enemy
{
    void Start()
    {
        actionBar = transform.Find("ActionBar");
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
        base.EnemySoundPlay();
    }
}
