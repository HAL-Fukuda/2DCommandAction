using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CommandMgr : MonoBehaviour
{
    // コンストラクタを private にすることで、クラスの外部からのインスタンス生成を防ぐ（シングルトンパターン）
    private CommandMgr() { }

    // このクラスのインスタンス（他スクリプトから参照するときはこのインスタンスを介して行う）
    public static CommandMgr instance = null;

    public static CommandMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CommandMgr>(); // この処理重いかも。
            }
            return instance;
        }
    }

    // 変数定義-------------------------

    // 関数定義-------------------------
    
    // 攻撃が当たったときのコマンド選択処理
    public void AttackHit(GameObject selectedCommand)
    {
        selectedCommand.GetComponent<Command>().CommandHit();
    }
}

