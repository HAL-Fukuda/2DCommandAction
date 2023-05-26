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
        ENEMY_DIE,
        NEXT_FLOOR,
        DEBUG,
    }
    public eBattleState battleState; // 現在のバトルステート
    public eBattleState? previousState; // 直前のバトルステート

    private GameObject selectedCommand; // 選択されたコマンド
    private bool isCommandSelected = false; // コマンドが選択されているか

    public GameObject player; // プレイヤーオブジェクト
    private GameObject enemy; // 敵のオブジェクト

    private bool killedEnemy = false; // 敵を倒したかどうか
    private int killCount = 0; // 敵を倒した数

    private bool stageClear = false;
    public GameObject stageClearEffectPrefab; // ステージクリア演出
    
    public int battleNum;  //バトル数を設定する変数(各ステージで設定する)
    public bool deathFlag = false;  //敵が消えているかどうか

    // スクリプト定義
    private CommandMgr commandMgr;

    // 関数定義-------------------------

    // Start is called before the first frame update
    void Start()
    {
        stageClear = false;
        SpawnEnemy();
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

    private void StageClear()
    {
        battle = false;
        Instantiate(stageClearEffectPrefab);
    }

    // 敵を生成する
    public void SpawnEnemy()
    {
        // エネミーを生成
        EnemyMgr script = GetComponent<EnemyMgr>();
        script.SpawnEnemy(killCount);
        // エネミーのオブジェクトを取得
        enemy = script.GetEnemyData();
        // アクションバーを取得
        Transform transform = enemy.transform.Find("ActionBar");
        enemyActionBar = transform.gameObject;
        // フラグをリセット
        killedEnemy = false;
    }

    // 敵を削除する
    public void DeleteEnemy()
    {   
        killedEnemy = true;
        killCount++;
        // ３体倒したらステージクリア
        if(killCount == battleNum)
        {
            stageClear = true;
        }
    }

    // 選択されたコマンドを格納する
    public void SetCommand(GameObject command)
    {
        if (isCommandSelected) // すでにコマンドが選択されているとき
        {
            // 選択されているコマンドを削除
            Destroy(command);
        }

        if (battleState == eBattleState.COMMAND_SELECT && // コマンドセレクトの時
            playerActionBar.GetComponent<ActionBarControl>().IsReady()) // アクションバーが１００％の時
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

    public void DeathFlagChenge()
    {
        deathFlag = true;
    }
}
