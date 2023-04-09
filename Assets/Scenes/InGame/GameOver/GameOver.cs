using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject corsor;

    private enum eMenuCommand
    {
        CONTINUE = 0,
        STAGESELECT = 1,
    }

    private eMenuCommand menuIdx;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            int idx = corsor.GetComponent<CorsorController>().GetIndex();
            menuIdx = (eMenuCommand)idx;

            switch (menuIdx)
            {
                case eMenuCommand.CONTINUE:
                    // �����X�e�[�W���ĊJ
                    //SceneManager.LoadScene(stage);
                    break;
                case eMenuCommand.STAGESELECT:
                    // �X�e�[�W�Z���N�g��ʂ�
                    SceneManager.LoadScene("StageSelect");
                    break;
            }
        }
    }
}