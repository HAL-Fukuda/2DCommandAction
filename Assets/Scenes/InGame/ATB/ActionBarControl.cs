using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBarControl : MonoBehaviour
{
    public Slider slider;

    // 初期化処理
    public void ActionBarInitialize()
    {
        slider.value = 0.0f;    // バーをの値を0にする
    }

    // バーの値を増やす
    public void AddValue()
    {
        slider.value += 0.1f;    // １割増やす
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddValue();
        }
    }
}
