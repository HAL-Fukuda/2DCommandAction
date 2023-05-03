using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grifin : Enemy
{
    private Transform actionBar; // �A�N�V�����o�[
    bool initialized = false;

    void Start()
    {
        actionBar = transform.Find("ActionBar");
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
        if(actionBar.GetComponent<ActionBarControl>().IsReady() &&
            initialized == false){
            attackScript.FeatherAttackInitialize(); // �H��΂��U���̏���������
            initialized = true;
        }
    }

    public override void Attack()
    {
        //�G�ŗL�̍U�����Ă�
        attackScript.FeatherAttack();
        initialized = false;
        //base.EnemySoundPlay();
    }
}
