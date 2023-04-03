using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageWindow : MonoBehaviour
{
    public Text debugText;
    public string message = "";

    // Start is called before the first frame update
    void Start()
    {
        // テキストコンポーネントを取得する
        debugText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        // GameMgrのデバッグメッセージを取得する
        message = GetDebugMessage();
        if (!string.IsNullOrEmpty(message))
        {
            // デバッグメッセージを改行してテキストに追加する
            debugText.text += message + "\n";
        }
    }

    // メッセージを取得する
    public string GetDebugMessage()
    {
        message = "";

        //下の行で別スクリプトのmessageを呼び出す
        //debugText.text = onoff.message;

        // MessageWindowのテキストをクリアする
        //messageWindow.ClearText(); 

        return message;
    }

    public void ClearText()
    {
        // GameMgrのcaseが変わった時にテキストをクリアする
        debugText.text = "";
    }
}
