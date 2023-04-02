using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public GameObject[] lifeArray = new GameObject[5];
    public int lifePoint = 5;
    public int maxlifePoint = 5;

    // 被ダメージ
    // 引数の値の文だけHPが減る
    public void GetDamage(int value)
    {
        for (int i = 0; i < value; i++)
        {
            if (lifePoint > 0)
            {
                lifeArray[lifePoint - 1].SetActive(false);
                lifePoint--;
            }
            else
            {
                break;
            }
        }
    }

    // 回復
    // 引数の値の数だけHPが増える
    public void GetHeal(int value)
    {
        for (int i = 0; i < value; i++)
        {
            if (lifePoint < maxlifePoint)
            {
                lifePoint++;
                lifeArray[lifePoint - 1].SetActive(true);
            }
            else
            {
                break;
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetDamage(2);
        }

        else if (Input.GetMouseButtonDown(1))
        {
            GetHeal(3);
        }
    }
}
