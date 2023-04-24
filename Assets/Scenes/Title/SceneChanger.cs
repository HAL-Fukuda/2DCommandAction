using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public string sceneName = "StageSelect";
    public float fadetime;

    public void GameStart()
    {
        FadeManager.Instance.LoadScene("StageSelect", fadetime);
        //SceneManager.LoadScene("StageSelect");
    }

    public void ButtonExit()
    {
        Application.Quit();
    }
}