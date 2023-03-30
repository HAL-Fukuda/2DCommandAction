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

    // ４つのコマンドのそれぞれのGameObject
    public GameObject command1;
    public GameObject command2;
    public GameObject command3;
    public GameObject command4;

    // 関数定義-------------------------

    //追加
    public void HideCommand()
    {
        command1.SetActive(false);
        command2.SetActive(false);
        command3.SetActive(false);
        command4.SetActive(false);
    }
    public void ShowCommand()
    {
        command1.SetActive(true);
        command2.SetActive(true);
        command3.SetActive(true);
        command4.SetActive(true);
    }

    // 攻撃が当たったときのコマンド選択処理
    public void AttackHit(GameObject selectedCommand)
    {
        // 選択されたコマンドをアクティブにする
        selectedCommand.GetComponent<Command>().Activate();
        // GameMgrに選択されたコマンドを渡す
        GameMgr.Instance.SetCommand(selectedCommand);

        // 他のコマンドを非アクティブにする
        if (selectedCommand != command1)
        {
            command1.GetComponent<Command>().Deactivate();
        }
        if (selectedCommand != command2)
        {
            command2.GetComponent<Command>().Deactivate();
        }
        if (selectedCommand != command3)
        {
            command3.GetComponent<Command>().Deactivate();
        }
        if (selectedCommand != command4)
        {
            command4.GetComponent<Command>().Deactivate();
        }
    }

    // すべてのコマンドを非アクティブにする
    public void DeactivateALL()
    {
        command1.GetComponent<Command>().Deactivate();
        command2.GetComponent<Command>().Deactivate();
        command3.GetComponent<Command>().Deactivate();
        command4.GetComponent<Command>().Deactivate();
    }
}

