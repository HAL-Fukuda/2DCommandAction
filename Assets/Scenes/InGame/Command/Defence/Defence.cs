using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Command : MonoBehaviour
{
    public GameObject shield;

    bool shealdOnFlg = false;


    void ShealdAction()
    {
        if (shealdOnFlg == false)
        {
            ShealdActive();
            Invoke("ShealdNotActive", 3.0f);
        }
    }
    void ShealdActive()
    {
        if (shealdOnFlg == false)
        {
            shealdOnFlg = true;
            shield.SetActive(true);     //シールド展開
        }
    }

    void ShealdNotActive()
    {
        shield.SetActive(false);
        shealdOnFlg = false;
    }

    //private void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.B))
    //    {
    //        ShealdAction();
    //    }
    //}

}