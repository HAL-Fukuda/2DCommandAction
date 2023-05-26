using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : Enemy
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
        // ÉQÅ[ÉWÇ™ÇΩÇ‹Ç¡ÇΩÇÁ
        if (actionBar.GetComponent<ActionBarControl>().IsReady() && initialized == false)
        {
            attackScript.SporeInitialize();
            attackScript.HomingenergyInitialize();
            attackScript.HomingBombMissileInitialize();
            attackScript.ThunderboltAttackInitialize();
            initialized = true;
        }
    }

    public override void Attack()
    {
        PatternRandom();
        initialized = false;
        //base.EnemySoundPlay();
    }

    public override void PatternRandom()
    {
        switch (attackNum)
        {
            case 0:
                attackScript.InevitableAttack();
                break;
            case 1:
                attackScript.Spore();
                break;
            case 2:
                attackScript.HomingBombMissileAttack();
                break;
            case 3:
                attackScript.HomingenergyAttack();
                break;
            case 4:
                attackScript.ThunderboltAttack();
                break;
        }
    }

    public override void NextAttackNum()
    {
        //attackNum = 4;
        attackNum = Random.Range(0, 5);
    }
}
