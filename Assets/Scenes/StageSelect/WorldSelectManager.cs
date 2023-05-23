using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

using UnityEngine.SceneManagement;

public class WorldSelectManager : MonoBehaviour
{
    private GameObject WorldCanvas;
    public GameObject StageCanvas;
    public GameObject FirstSelect;

    private ScrollWorld scrollWorld;
    private bool CanPush = false;

    public float fadetime;

    //private GameObject eventSystem;

    private void Start()
    {
        WorldCanvas = GameObject.Find("WorldSelectCanvas");

        GameObject ScrollWorldObject = GameObject.Find("WorldSelectCanvas");
        scrollWorld = ScrollWorldObject.GetComponent<ScrollWorld>();
    }

    // �߂�{�^�����Ȃ�manager�����

    public void WorldSelecting(string world)
    {
        // ���[���h������
        FadeManager.Instance.LoadScene(world, fadetime);
        //SceneManager.LoadScene(world);
    }

    //public void WorldSelecting()
    //{
    //    if (scrollWorld.IsScrollWhich() == false)
    //    {
    //        StageCanvas.SetActive(true);
    //        EventSystem.current.SetSelectedGameObject(FirstSelect);
    //        WorldCanvas.SetActive(false);
    //    }
    //}
}
