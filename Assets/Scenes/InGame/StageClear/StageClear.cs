using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClear : MonoBehaviour
{
    public float fadetime;
    public GameObject corsor;
    public AudioClip selectSE;

    private enum eMenuCommand
    {
        NEXTSTAGE = 0,
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
                case eMenuCommand.NEXTSTAGE:
                    // 次のステージへ
                    int sceneIdx = PlayerPrefs.GetInt("preSceneIdx");
                    sceneIdx++;
                    string sceneName = SceneIndexMapper.instance.GetSceneNameByIndex(sceneIdx);
                    AudioSource.PlayClipAtPoint(selectSE, new Vector3(0, 2, -10));
                    FadeManager.Instance.LoadScene(sceneName, fadetime);
                    break;
                case eMenuCommand.STAGESELECT:
                    // ステージセレクト画面へ
                    AudioSource.PlayClipAtPoint(selectSE, new Vector3(0, 2, -10));
                    FadeManager.Instance.LoadScene("StageSelect", fadetime);
                    break;
            }
        }
    }
}
