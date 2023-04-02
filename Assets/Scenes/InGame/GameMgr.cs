using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class GameMgr : MonoBehaviour
{
    // コンストラクタを private にすることで、クラスの外部からのインスタンス生成を防ぐ（シングルトンパターン）
    private GameMgr() { }

    // このクラスのインスタンス（他スクリプトから参照するときはこのインスタンスを介して行う）
    private static GameMgr instance = null;

    public static GameMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameMgr>(); // この処理重いかも。
            }
            return instance;
        }
    }

    // 変数定義-------------------------

    public bool battle = true; // 戦闘中かどうか

    // バトルステート
    public enum eBattleState
    {
        COMMAND_SELECT,
        PLAYER,
        ENEMY,
        DEBUG,
    }
    public eBattleState battleState; // 現在のバトルステート
    public eBattleState? previousState; // 直前のバトルステート

    private GameObject selectedCommand; // 選択されたコマンド
    private bool isCommandSelected = false; // コマンドが選択されているか

    public GameObject player; // プレイヤーオブジェクト
    public GameObject enemy; // 敵のオブジェクト
    // プロトタイプ版では敵を直接指定するが、今後変更する必要がある。

    public MessageWindow messageWindow;

    // 関数定義-------------------------

    // Start is called before the first frame update
    void Start()
    {
        ActiveTimeBattleInitialize();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (battle)
        {
            // 戦闘更新処理
            ActiveTimeBattleUpdate();
            if(battle == false)
            {
                FinalizeBattle();
            }
        }
    }

    // 敵をセットする
    public void StoreEnemy(GameObject enemy)
    {
        this.enemy = enemy;
    }

    // 選択されたコマンドを格納する
    public void StoreCommand(GameObject command)
    {
        // アクションバーが100％のときだけコマンドを受け付ける
        if (playerActionBar.GetComponent<ActionBarControl>().IsReady())
        {
            isCommandSelected = true;
            this.selectedCommand = command;
        }
    }

    // 選択されたコマンドをnullにする
    public void UnstoreCommand()
    {
        isCommandSelected = false;
        selectedCommand = null;
    }

    // バトルを開始するための初期化
    public void InitializeBattle()
    {
        // ウィンドウを表示する
        // 敵を配置する
        // BGMの再生
    }

    // バトル終了時の終了処理
    public void FinalizeBattle()
    {
        // ウィンドウを閉じる
        // BGMを停止する
    }

    // メッセージを取得する
    public string GetDebugMessage()
    {
        string message = "";

        // 直前のバトルステートと比較
        if (previousState != battleState)
        {
            messageWindow.ClearText(); // MessageWindowのテキストをクリアする
            message = battleState.ToString(); // ステートが変更された時のみ表示
            previousState = battleState;
        }

        return message;
    }
}
