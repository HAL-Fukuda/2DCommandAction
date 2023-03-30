using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Command : MonoBehaviour
{
    // 変数定義-------------------------

    public Material materialStandard; // 非アクティブ時のマテリアル
    public Material materialActive; // アクティブ時のマテリアル

    // コマンドの種類
    public enum eCommandType
    {
        NONE,
        ATTACK,
        ITEM,
    }

    public eCommandType commandType;

    public bool isActive = false; // アクティブかどうか

    private MeshRenderer meshRenderer;

    // 関数定義-------------------------

    // Start is called before the first frame update
    void CommandInitialize()
    {
        meshRenderer = this.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void CommandUpdate()
    {

    }

    // アクティブ状態を取得する
    public bool IsActive()
    {
        return isActive;
    }

    // 衝突時
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // タグがPunchかどうか
        if (collision.gameObject.CompareTag("Punch"))
        {
            // コマンドに攻撃が当たった時の処理を呼び出す
            CommandMgr.Instance.AttackHit(this.gameObject);
        }
        // エフェクト再生
        CommandEffectOnCollisionEnter(collision);
    }

    // アクティブ状態にする
    public void Activate()
    {
        isActive = true;
        meshRenderer.material = materialActive;
    }

    // 非アクティブ状態にする
    public void Deactivate()
    {
        isActive = false;
        meshRenderer.material = materialStandard;
    }
}
