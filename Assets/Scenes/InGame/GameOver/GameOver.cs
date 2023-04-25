using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public float fadetime;
    public GameObject corsor;

    private enum eMenuCommand
    {
        CONTINUE = 0,
        STAGESELECT = 1,
    }

    private eMenuCommand menuIdx;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || (Input.GetButtonDown("A")))
        {
            int idx = corsor.GetComponent<CorsorController>().GetIndex();
            menuIdx = (eMenuCommand)idx;

            switch (menuIdx)
            {
                case eMenuCommand.CONTINUE:
                    // 同じステージを再開
                    //SceneManager.LoadScene(stage);
                    break;
                case eMenuCommand.STAGESELECT:
                    // ステージセレクト画面へ
                    FadeManager.Instance.LoadScene("StageSelect", fadetime);
                    //SceneManager.LoadScene("StageSelect");
                    break;
            }
        }
    }
}
