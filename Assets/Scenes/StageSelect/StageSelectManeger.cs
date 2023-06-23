using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.EventSystems;

public class StageSelectManeger : MonoBehaviour
{
    public float fadetime;

    public void StageSelect(string stage)
    {
        // ステージ名入力
        FadeManager.Instance.LoadScene(stage, fadetime);
        //SceneManager.LoadScene(stage);
    }

    private void Update()
    {
        if ((Input.GetKeyUp(KeyCode.Escape)) || (Input.GetButtonUp("B")))
        {
            FadeManager.Instance.LoadScene("StageSelect", fadetime);
        }
    }

}