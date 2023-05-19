using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissileType : Enemy
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

        // �Q�[�W�����܂�����
        if (actionBar.GetComponent<ActionBarControl>().IsReady() &&
            initialized == false)
        {
            attackScript.HomingBombMissileInitialize(); // �H��΂��U���̏���������
            initialized = true;
        }
    }

    public override void Attack()
    {
        attackScript.HomingBombMissileAttack();
        initialized = false;
        //base.EnemySoundPlay();
    }
}
