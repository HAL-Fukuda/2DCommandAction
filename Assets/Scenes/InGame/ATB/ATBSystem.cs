using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameMgr : MonoBehaviour
{
    // ATB風のシステムを使った戦闘処理
    public void ActiveTimeBattleUpdate()
    {
        // バトルステートに応じた処理
        switch (battleState)
        {
            case eBattleState.COMMAND_SELECT: // 待機中

                // アクションバーを更新する
                //enemy.GetComponent<ActionBarControl>().ActionBarUpdate();
                //player.GetComponent<ActionBarControl>().ActionBarUpdate();

                // 行動が選択されたらバトルステートを変える
                //if (player.GetComponent<ActionBarControl>().IsReady())
                if (false)
                {
                    battleState = eBattleState.PLAYER;
                }
                //if (enemy.GetComponent<ActionBarControl>().IsReady())
                if (false)
                {
                    battleState = eBattleState.ENEMY;

                }
                break;

            case eBattleState.PLAYER: // 待機中

                // アクションバーを0％にセット
                //player.GetComponent<ActionBarControl>().SetEmpty();

                // プレイヤーの行動(コマンドの処理)
                CommandUpdate();

                // コマンドの処理が終了したらバトルステートを変える
                //CommandMgr.Instance().IsAction(); // 処理中かどうか
                if (true)
                {
                    battleState = eBattleState.COMMAND_SELECT;
                }
                break;

            case eBattleState.ENEMY: // 待機中

                // アクションバーを0％にセット
                //enemy.GetComponent<ActionBarControl>().SetEmpty();
                
                // 敵の行動
                EnemyUpdate();

                // 行動が終了したらバトルステートを変える
                //EnemyMgr.Instance().IsAction(); // 処理中かどうか
                if (true)
                {
                    battleState = eBattleState.COMMAND_SELECT;
                }
                break;
        }
    }

    private void CommandUpdate()
    {
        // コマンドの処理を実行
        //CommandMgr.Instance().Action();
    }

    private void EnemyUpdate()
    {
        // 敵の攻撃
        //EnemyMgr.Instance().Action();
    }
}

