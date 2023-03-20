using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
    public eBattleState battleState; // 現在のバトルステート

    private GameObject selectedCommand; // 選択されたコマンド

    private GameObject enemy; // 敵のオブジェクト

    private eBattleState previousState; // 直前のバトルステート

    // 関数定義-------------------------

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (battle)
        {
            // 戦闘更新処理
            BattleUpdate();
        }
    }

    // 敵をセットする
    public void SetEnemy(GameObject enemy)
    {
        this.enemy = enemy;
    }

    // 選択されたコマンドをセットする
    public void SetCommand(GameObject command)
    {
        this.selectedCommand = command;
    }

    // バトルを開始するための初期化
    public void InitializeBattle()
    {
        battle = true;
        battleState = eBattleState.COMMAND_SELECT;
        selectedCommand = null;
        CommandMgr.Instance.DeactivateALL();
    }

    private void BattleUpdate()
    {
        // バトルステートに応じた処理
        switch (battleState)
        {
            case eBattleState.COMMAND_SELECT: // コマンド選択
                if(selectedCommand != null && selectedCommand.GetComponent<Command>().IsActive())
                {
                    // コマンドが選択されていたらプレイヤーの行動へ
                    battleState = eBattleState.PLAYER;
                }
                Debug.Log("コマンド選択");
                break;

            case eBattleState.PLAYER: // プレイヤーの行動
                if (selectedCommand != null)
                {
                    // 選択されたコマンドに応じた処理
                    switch (selectedCommand.GetComponent<Command>().commandType)
                    {
                        case Command.eCommandType.ATTACK: // たたかう
                            Debug.Log("ATTACK");
                            break;
                        case Command.eCommandType.ITEM: // アイテム
                            Debug.Log("ITEM");
                            break;
                    }
                    // コマンドをリセットする
                    selectedCommand = null;
                    CommandMgr.Instance.DeactivateALL();
                    // 敵の行動へ
                    battleState = eBattleState.ENEMY;
                }
                Debug.Log("プレイヤーの行動");
                break;

            case eBattleState.ENEMY: // 敵の行動
                //enemy.GetComponent<Enemy>().Action();
                //if (enemy.GetComponent<Enemy>().IsActive() != true)
                //{
                //    battleState = eBattleState.COMMAND_SELECT;
                //}

                Debug.Log("敵の行動");
                break;
        }
    }

    // デバッグ用にメッセージを取得する
    public string GetDebugMessage()
    {
        string message = "";

        // 直前のバトルステートと比較
        if (previousState != battleState)
        {
            message = "【" + battleState.ToString() + "】"; // ステートが変更されたときのみ表示
            previousState = battleState;
        }

        //switch (battleState)
        //{
        //    case eBattleState.COMMAND_SELECT: // コマンド選択
        //        message = "コマンド選択中";
        //        break;

        //    case eBattleState.PLAYER: // プレイヤーの行動
        //        message = "プレイヤーの行動中";
        //        break;

        //    case eBattleState.ENEMY: // 敵の行動
        //        message = "敵の行動中";
        //        break;
        //}
        return message;
    }
}
