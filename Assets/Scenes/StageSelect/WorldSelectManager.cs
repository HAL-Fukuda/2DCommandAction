using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class WorldSelectManager : MonoBehaviour
{
    private GameObject WorldCanvas;
    public GameObject StageCanvas;
    public GameObject FirstSelect;

    //private GameObject eventSystem;

    private void Start()
    {
        WorldCanvas = GameObject.Find("WorldSelectCanvas");
    }

    // ñﬂÇÈÉ{É^ÉìçÏÇÈÇ»ÇÁmanagerçÏÇ¡Çƒ

    public void WorldSelecting()
    {
        StageCanvas.SetActive(true);
        EventSystem.current.SetSelectedGameObject(FirstSelect);
        WorldCanvas.SetActive(false);
    }
}
