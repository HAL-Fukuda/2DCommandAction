using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneIndexMapper : MonoBehaviour
{
    public static SceneIndexMapper instance;

    // シーン名を格納する配列
    public string[] sceneNames;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // シーン名を配列に設定する
        sceneNames = new string[SceneManager.sceneCountInBuildSettings];
        for (int i = 0; i < sceneNames.Length; i++)
        {
            sceneNames[i] = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
        }
    }

    // インデックスからシーン名を取得するメソッド
    public string GetSceneNameByIndex(int index)
    {
        if (index >= 0 && index < sceneNames.Length)
        {
            return sceneNames[index];
        }
        else
        {
            Debug.LogError("Invalid scene index!");
            return null;
        }
    }
}
