using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stageselect : MonoBehaviour
{
    public void ButtonClicked()
    {
        SceneManager.LoadScene("StageSelect");
        Debug.Log("‚¨‚³‚ê‚Ü‚µ‚½");
    }
}
