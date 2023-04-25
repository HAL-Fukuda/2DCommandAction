using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class WorldSelectManager : MonoBehaviour
{
    private GameObject WorldCanvas;
    public GameObject StageCanvas;
    public GameObject FirstSelect;

    private ScrollWorld scrollWorld;
    private bool CanPush = false;

    //private GameObject eventSystem;

    private void Start()
    {
        WorldCanvas = GameObject.Find("WorldSelectCanvas");

        GameObject ScrollWorldObject = GameObject.Find("WorldSelectCanvas");
        scrollWorld = ScrollWorldObject.GetComponent<ScrollWorld>();
    }

    // ñﬂÇÈÉ{É^ÉìçÏÇÈÇ»ÇÁmanagerçÏÇ¡Çƒ

    public void WorldSelecting()
    {
        if (scrollWorld.IsScrollWhich() == false)
        {
            StageCanvas.SetActive(true);
            EventSystem.current.SetSelectedGameObject(FirstSelect);
            WorldCanvas.SetActive(false);
        }
    }
}
