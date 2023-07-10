using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BackWorldSelect : MonoBehaviour
{
    public float fadetime;
    public AudioClip callSE;

    private void Update()
    {
        if ((Input.GetKeyUp(KeyCode.Escape)) || (Input.GetButtonUp("B")))
        {
            AudioSource.PlayClipAtPoint(callSE, new Vector3(0, 2, -10));
            FadeManager.Instance.LoadScene("StageSelect", fadetime);
        }
    }

}
