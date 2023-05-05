using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClear : MonoBehaviour
{
    public float fadetime;
    public GameObject corsor;

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
                    // ���̃X�e�[�W��
                    int sceneIdx = PlayerPrefs.GetInt("preSceneIdx");
                    sceneIdx++;
                    SceneManager.LoadScene(sceneIdx);
                    break;
                case eMenuCommand.STAGESELECT:
                    // �X�e�[�W�Z���N�g��ʂ�
                    FadeManager.Instance.LoadScene("StageSelect", fadetime);
                    break;
            }
        }
    }
}
