using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMgr : MonoBehaviour
{

    bool updateflag = true;
    [SerializeField] private GameObject AnyPress;
    [SerializeField] private GameObject Setting; // 操作説明画面のUIオブジェクト
    [SerializeField] private GameObject GameStart;
    [SerializeField] private GameObject Exit;

    void Start()
    {
        AnyPress.SetActive(true);
        Setting.SetActive(false);
        GameStart.SetActive(false);
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
            AnyPress.SetActive(false);
            Setting.SetActive(true);
            GameStart.SetActive(true);
            Exit.SetActive(true);
        }
    }
}
