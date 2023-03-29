using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{

    public PlatformEffector2D platformEffector2D;

    private void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            Through();  // Sキーを押して床をすり抜ける
        }
    }
    public void Through()
    {
        platformEffector2D.surfaceArc = 0;  //床のすり抜け
        Invoke("Reset", 0.5f);  //少し時間を置いてすり抜けた床を戻す
    }

    private void Reset()
    {
        platformEffector2D.surfaceArc = 120;　// すり抜けた床を戻す
    }
}
