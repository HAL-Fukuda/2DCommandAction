using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRobot : Enemy
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
        // �A�N�V�����o�[�����܂�������s
        if (actionBar.GetComponent<ActionBarControl>().IsReady() && initialized == false)
        {
            attackScript.BombMissileInitialize();
            attackScript.LaserIrradiationInitialize();
            initialized = true;
        }
    }

    public override void Attack()
    {
        PatternRandom();  //�U�����Ă�
        initialized = false;
        //base.EnemySoundPlay();
    }

    public override void PatternRandom()
    {
        string text;

        switch (attackNum)
        {
            case 0:
                text = "";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.BombMissileAttack();
                break;
            case 1:
                text = "";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.SatelliteBeam();
                break;
            case 2:
                text = "";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.LaserIrradiation();
                break;
        }
    }

    public override void NextAttackNum()
    {
        attackNum = Random.Range(0, 3);
    }
}
