using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowONOFF : MonoBehaviour
{
    [SerializeField] GameObject quad;  //windowのオブジェクトを取得

    bool WindowStat = true;

    void WindowSwitch()
    {
        if (Input.GetKeyUp(KeyCode.O))
        {
            if (quad.activeSelf)
            {
                quad.SetActive(false);
            }
            else
            {
                quad.SetActive(true);
            }
            Debug.Log(quad.activeSelf);
        }
        
    }

    void Update()
    {
        WindowSwitch();
    }
}
//if (Input.GetKey(KeyCode.O))
//{
//    if (WindowStat == true)
//    {
//        if (quad.activeSelf)
//        {
//            quad.SetActive(false);
//            WindowStat = false;
//        }
//    }
//    else if(WindowStat == false)
//    {
//        if (quad.activeSelf)
//        {
//            quad.SetActive(true);
//            WindowStat = true;
//        }
//    }
//}
////Debug.Log(quad.activeSelf);
//Debug.Log(WindowStat);