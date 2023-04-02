using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBarControl : MonoBehaviour
{
    public Slider slider;
    public float speed = 0.1f; // 増加スピード
    private bool isReady = false; // 100%かどうか

    // 初期化処理（バトル開始時に呼び出す）
    public void ActionBarInitialize()
    {
        slider.value = 0.0f; // バーをの値を0にする
        isReady = false; // 準備完了フラグをfalseにする
    }

    // 更新処理
    public void ActionBarUpdate()
    {
        // アクションバーが100％かどうか
        if (slider.value >= 1.0f)
        {
            isReady = true;
        }

        // 100%じゃなければ値を増加させる
        if (!isReady)
        {
            slider.value += speed / 100; // ※アクションバーの値は 100% = 1.0f なのでspeedの値をそのまま％になるように
        }
    }

    // アクションバーを空にする
    public void SetEmpty()
    {
        isReady = false;
        slider.value = 0.0f;
    }

    // isReadyの値を取得
    public bool IsReady()
    {
        return isReady;
    }
}
