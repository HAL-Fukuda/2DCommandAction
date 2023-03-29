using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageONOFF : MonoBehaviour
{
    [SerializeField] GameObject text;  //window�̃I�u�W�F�N�g���擾
    [SerializeField] GameObject quad;  //window�̃I�u�W�F�N�g���擾

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