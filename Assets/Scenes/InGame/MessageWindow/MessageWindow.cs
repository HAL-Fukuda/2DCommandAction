using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageWindow : MonoBehaviour
{
    // コンストラクタを private にすることで、クラスの外部からのインスタンス生成を防ぐ（シングルトンパターン）
    private MessageWindow() { }

    // このクラスのインスタンス（他スクリプトから参照するときはこのインスタンスを介して行う）
    private static MessageWindow instance = null;

    public static MessageWindow Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MessageWindow>(); // この処理重いかも。
            }
            return instance;
        }
    }

    public Text debugText;
    public string message = "";
    private string oldMessage;

    // Start is called before the first frame update
    void Start()
    {
        // テキストコンポーネントを取得する
        debugText = GetComponent<Text>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DrawMessage();
    }

    // メッセージをセットする
    public void SetDebugMessage(string text)
    {
        message = text;
    }

    public void ClearText()
    {
        // GameMgrのcaseが変わった時にテキストをクリアする
        debugText.text = "";
    }

    private void DrawMessage()
    {
        if (!string.IsNullOrEmpty(message) && message != oldMessage)
        {
            // テキストをクリア
            ClearText();
            // デバッグメッセージを改行してテキストに追加する
            debugText.text += message + "\n";
            oldMessage = message;
        }
    }
}
