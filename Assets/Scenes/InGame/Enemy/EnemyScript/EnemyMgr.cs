using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----------------------------------------------
// エネミーの生成などの管理はすべてここで行う
//----------------------------------------------

public class EnemyMgr : MonoBehaviour
{
    public GameObject dragon;
    public GameObject slime;
    public GameObject goblin;
    public GameObject zombie;
    public GameObject skelton;


    public bool isAction; // 行動中かどうか

    void EnemyMgrInitialize()
    {

    }

    void EnemyMgrUpdate()
    {

    }

    public void Action()
    {
        isAction = true;

        // 攻撃開始

        // 攻撃処理

        // 攻撃終了

        isAction = false;
    }
}
