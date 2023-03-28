using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public string sceneName = "StageSelect";

    public void GameStart()
    {
        SceneManager.LoadScene("StageSelect");
    }
}