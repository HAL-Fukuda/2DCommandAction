using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class STAGE_CLEAR : MonoBehaviour
{
    [SerializeField] private GameObject prefab_FINISH;
    [SerializeField] private GameObject prefab_STAGECLEAR;

    public float dropSpeed = 1.0f;
    public Vector2 drawPosition;

    void Start()
    {
        // 画面上に配置
        prefab_FINISH.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 700);
        prefab_FINISH.SetActive(true);

        // 画面中心に落ちてくる
        prefab_FINISH.GetComponent<RectTransform>().DOAnchorPos(drawPosition, dropSpeed).SetEase(Ease.InQuad).OnComplete(() =>
        {
            // 処理が終わったら１秒後に画面上に戻る
            prefab_FINISH.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 700), dropSpeed).SetDelay(1f).OnComplete(() =>
            {
                // 画面上に配置
                prefab_STAGECLEAR.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 700);
                prefab_STAGECLEAR.SetActive(true);

                // 画面中心に落ちてくる
                prefab_STAGECLEAR.GetComponent<RectTransform>().DOAnchorPos(drawPosition, dropSpeed).SetEase(Ease.InQuad).OnComplete(() =>
                {
                    // 処理が終わったら１秒後に画面上に戻る
                    prefab_STAGECLEAR.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 700), dropSpeed).SetDelay(1f).OnComplete(() =>
                    {
                        // オブジェクト削除
                        Destroy(gameObject);
                        // ステージセレクト画面へ
                        SceneManager.LoadScene("StageSelect");
                    });
                });
            });
        });
    }
}
