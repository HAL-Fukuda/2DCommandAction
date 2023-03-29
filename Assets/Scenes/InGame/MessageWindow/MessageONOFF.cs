using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageONOFF : MonoBehaviour
{
    [SerializeField] GameObject text;  //windowのオブジェクトを取得
    [SerializeField] GameObject quad;  //windowのオブジェクトを取得

    public bool MessageStat = true;
    public GameMgr gameMgr;

    void MessageSwitch()
    {
        if (text.GetComponent<Text>().text == "")
        {
            quad.SetActive(false);
            MessageStat = false;
        }
        else if (text.activeSelf)
        {
            quad.SetActive(true);
            MessageStat = true;
        }
    }

    void Update()
    {
        MessageSwitch();
    }
}