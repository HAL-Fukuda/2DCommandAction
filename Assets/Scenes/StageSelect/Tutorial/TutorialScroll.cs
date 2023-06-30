using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

using UnityEngine.SceneManagement;


//////////////////////////////////////
//
// panelのオンオフで複数panelを管理
// 表示するpanel以外全てオフにするスクリプトをifかswitchで
//
//
////////////////////////////////////////

public class TutorialScroll : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;

    private int NowPanel = 1;

    private bool IsScroll = false;

    private GameObject[] panelObject = new GameObject[5];

    public float fadetime;

    

    public void IsScrollFalse()
    {
        IsScroll = false;
    }

    public bool IsScrollWhich()
    {
        return IsScroll;
    }


    // Start is called before the first frame update
    void Start()
    {
        panelObject[0] = panel1;
        panelObject[1] = panel2;
        panelObject[2] = panel3;
        panelObject[3] = panel4;
        panelObject[4] = panel5;


        NowPanel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if ((Input.GetKeyUp(KeyCode.A) || (horizontalInput < 0)))    // 左キー代わり
        {
            
        }

        if ((Input.GetKeyUp(KeyCode.D) || (horizontalInput > 0)))  // 右キー代わり
        {
            
        }


        // 多分panelの親がステージセレクトのスクリプト持ってる
        //if ((Input.GetKeyUp(KeyCode.Escape)) || (Input.GetButtonUp("B")))
        //{
        //    if (IsScroll == false)
        //    {
        //        FadeManager.Instance.LoadScene("Title", fadetime);
        //    }
        //}
    }
}
