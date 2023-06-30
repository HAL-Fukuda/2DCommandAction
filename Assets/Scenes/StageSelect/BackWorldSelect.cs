using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BackWorldSelect : MonoBehaviour
{
    public float fadetime;

    private void Update()
    {
        if ((Input.GetKeyUp(KeyCode.Escape)) || (Input.GetButtonUp("B")))
        {
            FadeManager.Instance.LoadScene("StageSelect", fadetime);
        }
    }

}
