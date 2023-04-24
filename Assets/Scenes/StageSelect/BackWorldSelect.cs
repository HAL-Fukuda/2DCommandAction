using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class BackWorldSelect : MonoBehaviour
{
    public GameObject WorldCanvas;
    public GameObject StageCanvas;
    public GameObject FirstSelect;

    public void BackWorldSelecting()
    {
        WorldCanvas.SetActive(true);
        EventSystem.current.SetSelectedGameObject(FirstSelect);
        StageCanvas.SetActive(false);
    }

    //private void Start()
    //{
    //    WorldCanvas = GameObject.Find("WorldSelectCanvas");
    //}

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            BackWorldSelecting();
        }
    }

}
