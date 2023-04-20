using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.EventSystems;

public class StageSelectManeger : MonoBehaviour
{
    //public GameObject WorldCanvas;
    //public GameObject StageCanvas;
    //public GameObject FirstSelect;

    public void StageSelect(string stage)
    {
        // ステージ名入力
        SceneManager.LoadScene(stage);
    }

    //public void BackWorldSelecting()
    //{
    //    WorldCanvas.SetActive(true);
    //    EventSystem.current.SetSelectedGameObject(FirstSelect);
    //    StageCanvas.SetActive(false);
    //}

    //private void Start()
    //{
    //    WorldCanvas = GameObject.Find("WorldSelectCanvas");
    //}

    //private void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.X))
    //    {
    //        BackWorldSelecting();
    //    }
    //}

}