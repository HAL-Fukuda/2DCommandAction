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
        //敵固有の攻撃を呼ぶ
        base.AttackMode();
        //base.EnemySoundPlay();
    }

    public override void PatternCnt()
    {
        Debug.Log("Cnt");
        if (patternCnt <= 2)
        {
            attackScript.ClubSwing();  //攻撃を呼ぶ
            Debug.Log("一つ目の攻撃");
            Debug.Log(patternCnt);
        }
        else if (patternCnt >= 3)
        {
            attackScript.ClubBeating();  //攻撃を呼ぶ
            Debug.Log("二つ目の攻撃");
            patternCnt = 1;
        }

        patternCnt++;
    }
    
    public override void PatternSwitch()  //攻撃するたびに攻撃を切り替える
    {
        Debug.Log(patternSwitch);

        if (patternSwitch)
        {
            attackScript.ClubSwing();  //攻撃を呼ぶ
            patternSwitch = false;
        }
        else
        {
            attackScript.ClubBeating();  //攻撃を呼ぶ
            patternSwitch = true;
        }
    }
}
