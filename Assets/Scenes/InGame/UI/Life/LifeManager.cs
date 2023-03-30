using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public GameObject[] lifeArray = new GameObject[5];
    private int lifePoint = 5;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)/* && lifePoint < 5*/)
        {
            Lifeplus();
        }

        else if (Input.GetMouseButtonDown(1) && lifePoint > 0)
        {
            lifeArray[lifePoint - 1].SetActive(false);
            lifePoint--;
        }
    }

    void Lifeplus()
    {
        if(lifePoint < 5)
        {
            lifePoint++;
            lifeArray[lifePoint - 1].SetActive(true);
        }
    }
}
