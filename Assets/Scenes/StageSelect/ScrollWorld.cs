using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

using UnityEngine.SceneManagement;

public class ScrollWorld : MonoBehaviour
{
    public GameObject world1;
    public GameObject world2;
    public GameObject world3;
    public GameObject world4;
    public GameObject world5;

    private int NowL;
    private int NowR;
    private int NowC;

    private bool IsScroll = false;

    private GameObject[] worldObject = new GameObject[5];

    public void moveLeft()
    {
        if (NowL != -1)
        {
            // 選択ボタンの優先度の為の+ NowL
            worldObject[NowL].transform.DOLocalMove(new Vector3(-1800 + NowL, 0, 0), 0.2f);
        }
    }

    public void moveRight()
    {
        if (NowR < 5)
        {
            // 選択ボタンの優先度の為の+ NowR
            worldObject[NowR].transform.DOLocalMove(new Vector3(1800 + NowR, 0, 0), 0.2f);
        }
    }

    public void moveCenter()
    {
        worldObject[NowC].transform.DOLocalMove(new Vector3(0, 0, 0), 0.2f)
        .OnComplete(IsScrollFalse);
    }

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
        worldObject[0] = world1;
        worldObject[1] = world2;
        worldObject[2] = world3;
        worldObject[3] = world4;
        worldObject[4] = world5;

        NowL = -1;
        NowC = 0;
        NowR = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if ((Input.GetKeyUp(KeyCode.A) || (horizontalInput < 0)))    // 左キー代わり
        {
            if (NowC > 0 && IsScroll == false)
            {
                IsScroll = true;
                NowL -= 1;
                NowC -= 1;
                NowR -= 1;
                moveLeft();
                moveCenter();
                moveRight();
            }
        }

        if ((Input.GetKeyUp(KeyCode.D) || (horizontalInput > 0)))  // 右キー代わり
        {
            if (NowC < 4 && IsScroll == false)
            {
                IsScroll = true;
                NowL += 1;
                NowC += 1;
                NowR += 1;
                moveLeft();
                moveCenter();
                moveRight();
            }
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (IsScroll == false)
            {
                SceneManager.LoadScene("Title");
            }
        }
    }
}
