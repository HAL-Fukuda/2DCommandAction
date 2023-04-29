using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalGoblin : Enemy
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
        //attackNum = Random.Range(0, 2);

        //ìGå≈óLÇÃçUåÇÇåƒÇ‘
        attackScript.ClubSwing();
        //base.EnemySoundPlay();

        //switch (attackNum)
        //{
        //    case 0:
        //        attackScript.ClubBeating();
        //        //base.EnemySoundPlay();
        //        break;
        //    case 1:
        //        attackScript.ClubSwing();
        //        //base.EnemySoundPlay();
        //        break;
        //}
    }
}
