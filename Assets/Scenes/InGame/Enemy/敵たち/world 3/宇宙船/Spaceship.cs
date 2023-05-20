using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : Enemy
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
            initialized = true;
        }
    }

    public override void Attack()
    {
        Debug.Log(attackNum);
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
                attackScript.SatelliteBeam();
                break;
            case 2:
                attackScript.HomingBombMissileAttack();
                break;
        }
    }

    public override void NextAttackNum()
    {
        attackNum = 2;
        //attackNum = Random.Range(0, 3);
    }
}
