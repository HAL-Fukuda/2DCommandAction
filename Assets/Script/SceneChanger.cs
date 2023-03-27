using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public string sceneName = "Game";

    public void GameStart()
    {
        SceneManager.LoadScene(sceneName);
    }
}