using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.EventSystems;

public class StageSelectManeger : MonoBehaviour
{
    public float fadetime;
    public AudioClip callSE;

    public void StageSelect(string stage)
    {
        //AudioSource.PlayClipAtPoint(callSE, new Vector3(0, 2, -10));
        // �X�e�[�W������
        FadeManager.Instance.LoadScene(stage, fadetime);
        //SceneManager.LoadScene(stage);
    }
}