using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSoldier : Enemy
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
        if (actionBar.GetComponent<ActionBarControl>().IsReady() && initialized == false)
        {
            initialized = true;
        }
    }

    public override void Attack()
    {
        string text = "�S�u�����̐؂�t�����������I";
        MessageWindow.Instance.SetDebugMessage(text);
        attackScript.SlashingSword();
        initialized = false;
        //base.EnemySoundPlay();
    }
}