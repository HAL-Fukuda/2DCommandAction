using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stageselect : MonoBehaviour
{
    public float fadetime;

    public void ButtonClicked()
    {
        Time.timeScale = 1;
        FadeManager.Instance.LoadScene("StageSelect", fadetime);
        Debug.Log("‚¨‚³‚ê‚Ü‚µ‚½");
    }
}
