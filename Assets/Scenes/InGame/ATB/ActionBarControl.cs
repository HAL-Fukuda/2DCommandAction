using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBarControl : MonoBehaviour
{
    public Slider slider;

    // ����������
    public void ActionBarInitialize()
    {
        slider.value = 0.0f;    // �o�[���̒l��0�ɂ���
    }

    // �o�[�̒l�𑝂₷
    public void AddValue()
    {
        slider.value += 0.1f;    // �P�����₷
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddValue();
        }
    }
}
