using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusFormRed : Enemy
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
        // ゲージがたまったら
        if (actionBar.GetComponent<ActionBarControl>().IsReady() && initialized == false)
        {
            attackScript.HomingenergyInitialize();
            initialized = true;
        }
    }

    public override void Attack()
    {
        attackScript.HomingenergyAttack();
        initialized = false;
        //base.EnemySoundPlay();
    }
}
