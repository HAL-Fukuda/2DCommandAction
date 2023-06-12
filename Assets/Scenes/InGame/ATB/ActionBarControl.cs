using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBarControl : MonoBehaviour
{
    public Slider slider;
    public Image barImage; // バーの画像
    public float speed = 0.1f; // 増加スピード
    private bool isReady = false; // 100%かどうか

    public bool isFollowTarget;
    public Transform target;
    public Vector3 localPosition = new Vector3(0, 0, 0);

    private RectTransform uiElement;
    private RectTransform canvasRectTransform;

    public AudioClip FullSE;

    void Start()
    {
        if (isFollowTarget)
        {
            canvasRectTransform = this.transform.Find("Canvas") as RectTransform;
            uiElement = canvasRectTransform.transform.Find("Slider") as RectTransform;
        }
    }

    // 追従処理
    void FixedUpdate()
    {
        if(isFollowTarget)
        {
            Vector3 worldPos = target.position + localPosition; // 追従する位置を指定
            Vector2 screenPos = Camera.main.WorldToScreenPoint(worldPos);
            Vector2 canvasPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, screenPos, null, out canvasPos);

            uiElement.anchoredPosition = canvasPos;
        }
    }

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
            if(isReady == false)
            {
                isReady = true;

                // 100％になったタイミングでエフェクト処理
                if (isReady)
                {
                    AudioSource.PlayClipAtPoint(FullSE,new Vector3(0,0,0)); // SEを再生
                    ChangeColor(Color.cyan); // アクションバーの色を変更
                }
            }
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
        slider.value = 0.0f; // 0％にする
        ChangeColor(Color.yellow); // バーを黄色にする
    }

    // isReadyの値を取得
    public bool IsReady()
    {
        return isReady;
    }

    // ゲージの色を変える
    public void ChangeColor(Color color)
    {
        barImage.color = color;
    }
}
