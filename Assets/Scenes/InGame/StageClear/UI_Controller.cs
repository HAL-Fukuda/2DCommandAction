using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UI_Controller : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector2 position;

    public enum eDrawType
    {
        DROP,
        FADE,
    }
    public eDrawType drawType = eDrawType.DROP;
    
    // Start is called before the first frame update
    void Start()
    {
        Draw(drawType);
    }

    private void Draw(eDrawType type)
    {
        switch (type)
        {
            case eDrawType.DROP:
                Drop();
                break;
            
            case eDrawType.FADE:
                Fade();
                break;
        }
    }

    private void Drop()
    {
        // 画面上に配置
        this.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,700);

        // 画面中心に落ちてくる
        this.GetComponent<RectTransform>().DOAnchorPos(position, speed).SetEase(Ease.InQuad).OnComplete(() =>
        {
            // 処理が終わったら１秒後に画面上に戻る
            this.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 700), speed).SetDelay(1f).OnComplete(() =>
            {
                // オブジェクト削除
                Destroy(gameObject);
            });
        });
    }

    private void Fade()
    {
        // 透明度を０にする

        // 画面中心に配置

        // 透明度を１にする

        // １秒後透明度を０にする

        // オブジェクト削除
    }
}
