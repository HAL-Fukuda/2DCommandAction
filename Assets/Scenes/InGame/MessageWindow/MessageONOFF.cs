using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageONOFF : MonoBehaviour
{
    [SerializeField] GameObject quad;  //windowのオブジェクトを取得

    bool MessageStat = true;
    public GameMgr gameMgr;

    void MessageSwitch()
    {
        if (gameMgr.previousState != gameMgr.battleState)
        {
            if (quad.activeSelf)
            {
                quad.SetActive(true);
                MessageStat = true;
            }
            else
            {
                quad.SetActive(false);
                MessageStat = false;
            }
            //Debug.Log(quad.activeSelf);
            //Debug.Log(MessageStat);
        }
    }

    void Update()
    {
        MessageSwitch();
    }
}