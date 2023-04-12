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
            if (battle == false)
            {
                FinalizeBattle();
            }
        }
    }

    // 敵をセットする
    public void SetEnemy(GameObject enemy)
    {
        this.enemy = enemy;
    }

    // 敵を削除する
    public void DeleteEnemy()
    {
        Destroy(this.enemy);
    }

    // 選択されたコマンドを格納する
    public void SetCommand(GameObject command)
    {
        if (isCommandSelected) // すでにコマンドが選択されているとき
        {
            // 選択されているコマンドを削除
            DeleteCommand();
        }

        if(battleState == eBattleState.COMMAND_SELECT)
        {
            isCommandSelected = true;

            // コマンドをコピー
            selectedCommand = command;
        }
        else
        {
            Destroy(command);
        }
    }

    // 選択されたコマンドを削除する
    public void DeleteCommand()
    {
        isCommandSelected = false;

        Destroy(selectedCommand);
    }

    // コマンドが選択されているか
    public bool IsCommandSelected()
    {
        return isCommandSelected;
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
}
