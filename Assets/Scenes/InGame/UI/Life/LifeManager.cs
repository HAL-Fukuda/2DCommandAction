using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public GameObject[] lifeArray = new GameObject[5];
    private int lifePoint = 5;
    private int maxlifePoint = 5;

    void GetDamage(int value)
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

    void GetHeel(int value)
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
        if (Input.GetMouseButtonDown(0) && lifePoint < maxlifePoint)
        {
            GetHeel(1);
        }

        else if (Input.GetMouseButtonDown(1) && lifePoint > 0)
        {
            GetDamage(1);
        }
    }
}
