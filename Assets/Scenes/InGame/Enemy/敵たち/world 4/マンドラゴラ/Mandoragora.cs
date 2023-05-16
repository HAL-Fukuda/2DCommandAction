using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mandoragora : Enemy
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
        if (actionBar.GetComponent<ActionBarControl>().IsReady() &&�@initialized == false)
        {
            initialized = true;
        }
    }

    public override void Attack()
    {
        //�}���h���S���̍U��
        initialized = false;
        //base.EnemySoundPlay();
    }
}
