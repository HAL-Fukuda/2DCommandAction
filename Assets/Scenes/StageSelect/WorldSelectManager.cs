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

    // �߂�{�^�����Ȃ�manager�����

    public void WorldSelecting()
    {
        StageCanvas.SetActive(true);
        EventSystem.current.SetSelectedGameObject(FirstSelect);
        WorldCanvas.SetActive(false);
    }
}
