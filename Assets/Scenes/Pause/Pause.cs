using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    Button resume;
    Button select;

    public void InitializePause()
    {
        resume = GameObject.Find("Resume").GetComponent<Button>();
        select = GameObject.Find("StageSelect").GetComponent<Button>();

        resume.Select();
    }
}
