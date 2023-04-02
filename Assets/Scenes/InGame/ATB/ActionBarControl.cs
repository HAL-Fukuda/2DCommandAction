using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBarControl : MonoBehaviour
{
    public Slider slider;
    public float speed = 0.1f; // �����X�s�[�h
    private bool isReady = false; // 100%���ǂ���

    // �����������i�o�g���J�n���ɌĂяo���j
    public void ActionBarInitialize()
    {
        slider.value = 0.0f; // �o�[���̒l��0�ɂ���
        isReady = false; // ���������t���O��false�ɂ���
    }

    // �X�V����
    public void ActionBarUpdate()
    {
        // �A�N�V�����o�[��100�����ǂ���
        if (slider.value >= 1.0f)
        {
            isReady = true;
        }

        // 100%����Ȃ���Βl�𑝉�������
        if (!isReady)
        {
            slider.value += speed / 100; // ���A�N�V�����o�[�̒l�� 100% = 1.0f �Ȃ̂�speed�̒l�����̂܂܁��ɂȂ�悤��
        }
    }

    // �A�N�V�����o�[����ɂ���
    public void SetEmpty()
    {
        isReady = false;
        slider.value = 0.0f;
    }

    // isReady�̒l���擾
    public bool IsReady()
    {
        return isReady;
    }
}
