using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : Enemy
{
    //private GameObject enemyTag;

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
                //サテライトキャノン
                break;
            case 1:
                attackScript.BombMissileAttack();
                break;
            case 2:
                //レーザー
                break;
        }
    }

    public override void NextAttackNum()
    {
        //enemyTag = GameObject.Find("Robot(Clone)");
        //if (enemyTag.gameObject.CompareTag("Enemy"))
        //{
        //    Debug.Log("Enemyだよ");
        //}
        attackNum = Random.Range(0, 3);
    }
}
