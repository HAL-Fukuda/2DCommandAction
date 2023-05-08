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
        if (killFlag)
        {
            base.DestroyEffectSpawn();
        }
        if (hitFlag)
        {
            hitTime = hitTime + Time.deltaTime;
            Debug.Log(hitTime);

            base.GetDamegeEffectSpawn();

            if (hitTime > 10f)
            {
                hitFlag = false;
                hitTime = 0f;
            }
        }
    }

    public override void Attack()
    {
        //“GŒÅ—L‚ÌUŒ‚‚ğŒÄ‚Ô
        base.AttackMode();
        //base.EnemySoundPlay();
    }

    public override void PatternCnt()
    {
        Debug.Log("Cnt");
        if (patternCnt <= 2)
        {
            attackScript.ClubSwing();  //UŒ‚‚ğŒÄ‚Ô
            Debug.Log("ˆê‚Â–Ú‚ÌUŒ‚");
            Debug.Log(patternCnt);
        }
        else if (patternCnt >= 3)
        {
            attackScript.ClubBeating();  //UŒ‚‚ğŒÄ‚Ô
            Debug.Log("“ñ‚Â–Ú‚ÌUŒ‚");
            patternCnt = 1;
        }

        patternCnt++;
    }
    
    public override void PatternSwitch()  //UŒ‚‚·‚é‚½‚Ñ‚ÉUŒ‚‚ğØ‚è‘Ö‚¦‚é
    {
        Debug.Log(patternSwitch);

        if (patternSwitch)
        {
            attackScript.ClubSwing();  //UŒ‚‚ğŒÄ‚Ô
            patternSwitch = false;
        }
        else
        {
            attackScript.ClubBeating();  //UŒ‚‚ğŒÄ‚Ô
            patternSwitch = true;
        }
    }
}
