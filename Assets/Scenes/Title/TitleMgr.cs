using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMgr : MonoBehaviour
{
    bool updateflag = true;
    [SerializeField] private GameObject titleLogo; // タイトル画面のUIオブジェクト
    [SerializeField] private GameObject StartLogo;
    [SerializeField] private GameObject Setting; // 操作説明画面のUIオブジェクト
    [SerializeField] private GameObject GameStartLogo;
    [SerializeField] private GameObject Exit;

    void Start()
    {
        StartLogo.SetActive(true);
        Setting.SetActive(false);
        GameStartLogo.SetActive(false);
        Exit.SetActive(false);
    }

    void Update()
    {
        StartTitle();
    }

    // スタートボタンが押されたときの処理
    public void StartTitle()
    {
        if (Input.anyKey && updateflag == true)
        {
            updateflag = false;
            StartLogo.SetActive(false);
            Setting.SetActive(true);
            GameStartLogo.SetActive(true);
            Exit.SetActive(true);
        }
    }

    // 操作説明ボタンが押されたときの処理
    public void ShowInstructions()
    {

    }

    // 操作説明画面の戻るボタンが押されたときの処理
    public void HideInstructions()
    {

    }

    // ゲームを終了するボタンが押されたときの処理
    public void QuitGame()
    {
        Application.Quit();
    }
}
