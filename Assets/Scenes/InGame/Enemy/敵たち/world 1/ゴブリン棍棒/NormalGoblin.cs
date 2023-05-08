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
        //�G�ŗL�̍U�����Ă�
        base.AttackMode();
        //base.EnemySoundPlay();
    }

    public override void PatternCnt()
    {
        Debug.Log("Cnt");
        if (patternCnt <= 2)
        {
            attackScript.ClubSwing();  //�U�����Ă�
            Debug.Log("��ڂ̍U��");
            Debug.Log(patternCnt);
        }
        else if (patternCnt >= 3)
        {
            attackScript.ClubBeating();  //�U�����Ă�
            Debug.Log("��ڂ̍U��");
            patternCnt = 1;
        }

        patternCnt++;
    }
    
    public override void PatternSwitch()  //�U�����邽�тɍU����؂�ւ���
    {
        Debug.Log(patternSwitch);

        if (patternSwitch)
        {
            attackScript.ClubSwing();  //�U�����Ă�
            patternSwitch = false;
        }
        else
        {
            attackScript.ClubBeating();  //�U�����Ă�
            patternSwitch = true;
        }
    }
}
