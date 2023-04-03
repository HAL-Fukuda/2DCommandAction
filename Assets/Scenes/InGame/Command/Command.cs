using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Command : MonoBehaviour
{
    // 変数定義-------------------------


    // コマンドの種類
    public enum eCommandType
    {
        ATTACK,
        DEFENCE,
        HEAL
    }

    public eCommandType commandType;

    public bool isActive = false; // アクティブかどうか


    // 関数定義-------------------------

    void CommandInitialize()
    {

    }

    public void CommandAction()
    {
        Activate(); // アクティブ状態にする

        // コマンドに応じた処理
        switch (commandType)
        {
            case eCommandType.ATTACK:// 攻撃の処理    
                SlashEffectPlay();

                // 処理が終わったら非アクティブ状態にする
                Deactivate();

                break;
            case eCommandType.DEFENCE:// 防御の処理    
                ShealdAction();

                // 処理が終わったら非アクティブ状態にする
                Deactivate();
                break;
            case eCommandType.HEAL:// 回復の処理
                HealEffectPlay();

                // 処理が終わったら非アクティブ状態にする
                Deactivate();
                break;
        }

    }

    // アクティブ状態を取得する
    public bool IsActive()
    {
        return isActive;
    }

    // アクティブ状態にする
    public void Activate()
    {
        isActive = true;
    }

    // 非アクティブ状態にする
    public void Deactivate()
    {
        isActive = false;
    }
}
