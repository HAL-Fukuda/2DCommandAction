using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectManeger : MonoBehaviour
{
    public void StageSelect(int stage)
    {
        //”Ô†‡
        //File...BuildSettings...
        SceneManager.LoadScene(stage);
    }
}