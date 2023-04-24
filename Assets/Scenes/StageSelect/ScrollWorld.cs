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

    private GameObject[] worldObject = new GameObject[5];

    public void moveLeft()
    {
        if (NowL != -1)
        {
            // �I���{�^���̗D��x�ׂ̈�+ NowL
            worldObject[NowL].transform.DOLocalMove(new Vector3(-1800 + NowL, 0, 0), 0.2f);
        }
    }

    public void moveRight()
    {
        if (NowR < 5)
        {
            // �I���{�^���̗D��x�ׂ̈�+ NowR
            worldObject[NowR].transform.DOLocalMove(new Vector3(1800 + NowR, 0, 0), 0.2f);
        }
    }

    public void moveCenter()
    {
            worldObject[NowC].transform.DOLocalMove(new Vector3(0, 0, 0), 0.2f);
    }

    public void WorldSelecting()
    {
        // �X�e�[�W�Z���N�g
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
        
        if (Input.GetKeyUp(KeyCode.A))    // ���L�[����
        {
            if (NowC > 0) 
            {
                
                //endMove = true;
                NowL -= 1;
                NowC -= 1;
                NowR -= 1;
                moveLeft();
                moveCenter();
                moveRight();
            }
        }

        if (Input.GetKeyUp(KeyCode.D))  // �E�L�[����
        {
            if (NowC < 4)
            {
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
            SceneManager.LoadScene("Title");
        }
    }
}
