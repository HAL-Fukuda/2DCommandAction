using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameMgr : MonoBehaviour
{
    private float enemyTimer; // エネミー用タイマー
    private bool EnemyInitialize = false;   // パワーで解決用フラグ

    public const float enemyActionTime = 5.0f;

    private GameObject playerActionBar;
    private GameObject enemyActionBar;

    // 初期化処理
    public void ActiveTimeBattleInitialize()
    {
        battleState = eBattleState.COMMAND_SELECT; // バトルステート
        enemyTimer = enemyActionTime; // エネミー用タイマー

        // プレイヤーのアクションバーを取得
        Transform transform = player.transform.Find("ActionBar");
        playerActionBar = transform.gameObject;
    }

    // ATB風のシステムを使った戦闘処理
    public void ActiveTimeBattleUpdate()
    {
        if (killedEnemy) // 敵が死んでいたら
        {
            battleState = eBattleState.NEXT_FLOOR;
        }

        // バトルステートに応じた処理
        switch (battleState)
        {
            case eBattleState.COMMAND_SELECT: // 待機中
                // アクションバーを更新する
                playerActionBar.gameObject.GetComponent<ActionBarControl>().ActionBarUpdate();
                enemyActionBar.gameObject.GetComponent<ActionBarControl>().ActionBarUpdate();

                // アクションバーが１００％になったらテキストを表示する
                if (playerActionBar.GetComponent<ActionBarControl>().IsReady())
                {
                    string text = "コマンドを選択してください";
                    MessageWindow.Instance.SetDebugMessage(text);
                }

                // 行動が選択されたらバトルステートを変える
                if (playerActionBar.GetComponent<ActionBarControl>().IsReady() &&
                    isCommandSelected == true && EnemyInitialize == false)
                {
                    battleState = eBattleState.PLAYER;
                }
                if (enemyActionBar.GetComponent<ActionBarControl>().IsReady() &&
                    battleState == eBattleState.COMMAND_SELECT)
                {
                    string text = "敵の攻撃！";
                    MessageWindow.Instance.SetDebugMessage(text);

                    // 初期化処理
                    if (EnemyInitialize == false)
                    {
                        EnemyInitialize = true;
                        enemy.GetComponent<EnemyAttack>().EnemyAttackInitialize();
                    }

                    // エネミーのターン
                    if (enemy.GetComponent<EnemyAttack>().IsReady())
                    {
                        EnemyInitialize = false;
                        battleState = eBattleState.ENEMY;
                    }
                }
                break;

            case eBattleState.PLAYER: // プレイヤー

                // アクションバーを0％にセット
                playerActionBar.GetComponent<ActionBarControl>().SetEmpty();

                // プレイヤーの行動(コマンドの処理)
                selectedCommand.GetComponent<Command>().CommandAction();

                // コマンドの処理が終了したらバトルステートを変える
                if (!selectedCommand.GetComponent<Command>().IsActive())
                {
                    DeleteCommand(); // 選択されたコマンドの情報を無くす

                    battleState = eBattleState.COMMAND_SELECT;
                }
                break;

            case eBattleState.ENEMY: // エネミー

                enemyTimer -= Time.deltaTime;

                // アクションバーを0％にセット
                enemyActionBar.GetComponent<ActionBarControl>().SetEmpty();

                // 敵の行動
                enemy.GetComponent<Enemy>().Attack();

                // 時間が経ったら敵の行動終了
                if (enemyTimer <= 0.0f)
                {
                    enemyTimer = enemyActionTime;
                    battleState = eBattleState.COMMAND_SELECT;
                }
                break;
            case eBattleState.NEXT_FLOOR:

                // クリアしたかどうか
                if (stageClear)
                {
                    StageClear(); // クリア
                }
                else
                {
                    SpawnEnemy(); // エネミーを生成する
                    battleState = eBattleState.COMMAND_SELECT; // コマンドセレクトへ
                }
                break;
            default:
                break;
        }
    }
}