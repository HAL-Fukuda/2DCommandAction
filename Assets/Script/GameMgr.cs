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
    private enum eBattleState
    {
        COMMAND_SELECT,
        PLAYER,
        ENEMY,
    }
    private eBattleState battleState; // 現在のバトルステート

    private GameObject selectedCommand; // 選択されたコマンド

    public GameObject enemy; // 敵のオブジェクト
    // プロトタイプ版では敵を直接指定するが、今後変更する必要がある。

    private bool runningCoroutine;

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
        // 変数の初期化
        battle = true;
        battleState = eBattleState.COMMAND_SELECT;
        selectedCommand = null;
        CommandMgr.Instance.DeactivateALL();

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

    private void BattleUpdate()
    {
        // バトルステートに応じた処理
        switch (battleState)
        {
            case eBattleState.COMMAND_SELECT: // コマンド選択
                Debug.Log("コマンド選択");
                if (selectedCommand != null && selectedCommand.GetComponent<Command>().IsActive())
                {
                    // コマンドが選択されていたら少し待ってプレイヤーの行動へ
                    if (runningCoroutine != true)
                    {
                        StartCoroutine(ToPlayerAction(2));
                    }
                }
                break;

            case eBattleState.PLAYER: // プレイヤーの行動
                Debug.Log("プレイヤーの行動");
                if (selectedCommand != null)
                {
                    // 選択されたコマンドに応じた処理
                    switch (selectedCommand.GetComponent<Command>().commandType)
                    {
                        case Command.eCommandType.ATTACK: // たたかう
                            Debug.Log("ATTACK");

                            // 敵が地面に降りてくる
                            //enemy.GetComponent<Enemy>.ToGround();
                            EnemyToGround();

                            // 一定時間後にウィンドウに戻る
                            StartCoroutine(EnemyToWindow(2));

                            break;
                        case Command.eCommandType.ITEM: // アイテム
                            Debug.Log("ITEM");
                            break;
                    }
                    // 敵の行動へ
                    battleState = eBattleState.ENEMY;
                }
                else
                {
                    Debug.Log("selectedCommandがnull");
                }
                break;

            case eBattleState.ENEMY: // 敵の行動
                Debug.Log("敵の行動");
                if (enemy != null)
                {
                    // 流星群
                    enemy.GetComponent<EnemyAttack>().MeteorAttack();

                    // 一定時間後にコマンドを表示してコマンドセレクトへ
                    if (runningCoroutine != true)
                    {
                        StartCoroutine(ToCommandSelect(5));
                    }
                }
                break;
        }
    }

    // 仮プレイヤーの行動へ移行
    private IEnumerator ToPlayerAction(float delay)
    {
        runningCoroutine = true;

        // 一定時間待機
        yield return new WaitForSeconds(delay);

        // プレイヤーの行動へ移行する
        battleState = eBattleState.PLAYER;
        CommandMgr.Instance.HideCommand();
        Debug.Log("プレイヤーの行動へ");

        // コルーチンが完了したことを示すために null を返す
        runningCoroutine = false;
        yield return null;
    }

    // 仮コマンドセレクトへ移行
    private IEnumerator ToCommandSelect(float delay)
    {
        runningCoroutine = true;

        yield return new WaitForSeconds(delay);

        // コマンドをリセットする
        CommandMgr.Instance.ShowCommand();
        selectedCommand = null;
        CommandMgr.Instance.DeactivateALL();

        battleState = eBattleState.COMMAND_SELECT;

        Debug.Log("コマンドセレクトへ");

        // コルーチンが完了したことを示すために null を返す
        runningCoroutine = false;
        yield return null;
    }

    // 一定時間待機してから敵がウィンドウに移動する
    private IEnumerator EnemyToWindow(float delay)
    {
        runningCoroutine = true;

        // 一定時間待機
        yield return new WaitForSeconds(delay);
        // ウィンドウへ移動
        EnemyToWindow();

        // コルーチンが完了したことを示すために null を返す
        runningCoroutine = false;
        yield return null;
    }

    // デバッグ
    void EnemyToGround()
    {
        Debug.Log("敵が地面に移動する");
    }

    void EnemyToWindow()
    {
        Debug.Log("敵がウィンドウに移動する");
    }
}
