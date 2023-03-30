using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameMgr : MonoBehaviour
{
    public GameObject bar;

    // ATB風のシステムを使った戦闘処理
    public void ActiveTimeBattleUpdate()
    {
        // バトルステートに応じた処理
        switch (battleState)
        {
            case eBattleState.COMMAND_SELECT: // 待機中

                // アクションバーを更新する
                bar.GetComponent<ActionBarControl>().ActionBarUpdate();
                //enemy.GetComponent<ActionBarControl>().ActionBarUpdate();
                //player.GetComponent<ActionBarControl>().ActionBarUpdate();

                // 行動が選択されたらバトルステートを変える
                if (false)
                {
                    battleState = eBattleState.PLAYER;
                }
                //if (enemy.GetComponent<ActionBarControl>().IsReady())
                if (bar.GetComponent<ActionBarControl>().IsReady())
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
                if (true)
                {
                    battleState = eBattleState.COMMAND_SELECT;
                }
                break;

            case eBattleState.ENEMY: // 待機中

                // アクションバーを0％にセット
                //enemy.GetComponent<ActionBarControl>().SetEmpty();
                bar.GetComponent<ActionBarControl>().SetEmpty();
                
                // 敵の行動
                EnemyUpdate();

                // 行動が終了したらバトルステートを変える
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

