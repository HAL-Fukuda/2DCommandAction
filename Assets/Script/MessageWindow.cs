using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageWindow : MonoBehaviour
{
    public Text debugText;

    // Start is called before the first frame update
    void Start()
    {
        //debugText.text = "";

        // テキストコンポーネントを取得する
        debugText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // 例えば、現在のバトルステートを表示する
        //debugText.text = GameMgr.Instance.battleState.ToString();

        // GameMgrのデバッグメッセージを取得する
        string message = GameMgr.Instance.GetDebugMessage();
        if (!string.IsNullOrEmpty(message))
        {
            // デバッグメッセージを改行してテキストに追加する
            debugText.text += message + "\n";
        }
    }
}
