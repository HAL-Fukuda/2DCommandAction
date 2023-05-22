using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsMachineGunType : Enemy
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
            attackScript.BulletsMachinGunInitialize();
            initialized = true;
        }
    }

    public override void Attack()
    {
        attackScript.BulletsMachineGun();
        initialized = false;
        //base.EnemySoundPlay();
    }
}
