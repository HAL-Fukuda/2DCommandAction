using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileType : Enemy
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
            attackScript.BombMissileInitialize();
            initialized = true;
        }
    }

    public override void Attack()
    {
        //Debug.Log(attackNum);
        attackScript.BombMissileAttack();
        initialized = false;
        //base.EnemySoundPlay();
    }
}
