using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameMgr : MonoBehaviour
{
    private float enemyTimer; // エネミー用タイマー
    private bool enemyInitializeStart = false;   // 敵の攻撃の初期化が始まっているかどうか

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

        battle = true;
    }

    // ATB風のシステムを使った戦闘処理
    public void ActiveTimeBattleUpdate()
    {
        // バトルステートに応じた処理
        switch (battleState)
        {
            case eBattleState.COMMAND_SELECT: // 待機中
                if (killedEnemy) // 敵が死んでいたら
                {
                    battleState = eBattleState.ENEMY_DIE;
                }
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
                    isCommandSelected == true)
                {
                    battleState = eBattleState.PLAYER;
                }
                // アクションバーが１００％になったら敵の攻撃
                if (enemyActionBar.GetComponent<ActionBarControl>().IsReady() &&
                    battleState == eBattleState.COMMAND_SELECT)
                {
                    string text = "敵の攻撃！";
                    MessageWindow.Instance.SetDebugMessage(text);

                    battleState = eBattleState.ENEMY;
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

                // 初期化処理
                if (enemyInitializeStart == false)
                {
                    enemyInitializeStart = true;
                    enemy.GetComponent<EnemyAttack>().EnemyAttackInitialize();
                }

                // 敵の攻撃の初期化処理が終わっているか
                if (enemy.GetComponent<EnemyAttack>().IsReady())
                {
                    // タイマーを減らす
                    enemyTimer -= Time.deltaTime;

                    // アクションバーを0％にセット
                    enemyActionBar.GetComponent<ActionBarControl>().SetEmpty();

                    // 敵の行動
                    enemy.GetComponent<Enemy>().Attack();
                    
                    // 時間が経ったら敵の行動終了
                    if (enemyTimer <= 0.0f)
                    {  
                        enemy.GetComponent<Enemy>().NextAttackNum();
                        enemy.GetComponent<EnemyAttack>().EnemyAttackFinalize(); // 攻撃が終わったら終了処理を呼ぶ
                        enemyInitializeStart = false;
                        enemyTimer = enemyActionTime;
                        battleState = eBattleState.COMMAND_SELECT;
                    }
                }
                break;
            case eBattleState.ENEMY_DIE:
                if (deathFlag) // 敵が死んでいたら
                {
                    killedEnemy = false;
                    battleState = eBattleState.NEXT_FLOOR;
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
                    deathFlag = false;
                    battleState = eBattleState.COMMAND_SELECT; // コマンドセレクトへ
                }
                break;
            default:
                break;
        }
    }
}