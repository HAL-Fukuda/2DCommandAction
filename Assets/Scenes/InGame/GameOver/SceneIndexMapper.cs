using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneIndexMapper : MonoBehaviour
{
    public static SceneIndexMapper instance;

    // �V�[�������i�[����z��
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

        // �V�[������z��ɐݒ肷��
        sceneNames = new string[SceneManager.sceneCountInBuildSettings];
        for (int i = 0; i < sceneNames.Length; i++)
        {
            sceneNames[i] = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
        }
    }

    // �C���f�b�N�X����V�[�������擾���郁�\�b�h
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
