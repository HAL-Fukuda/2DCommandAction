using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageWindow : MonoBehaviour
{
    public Text debugText;
    public string message = "";

    // Start is called before the first frame update
    void Start()
    {
        // �e�L�X�g�R���|�[�l���g���擾����
        debugText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        // GameMgr�̃f�o�b�O���b�Z�[�W���擾����
        message = GetDebugMessage();
        if (!string.IsNullOrEmpty(message))
        {
            // �f�o�b�O���b�Z�[�W�����s���ăe�L�X�g�ɒǉ�����
            debugText.text += message + "\n";
        }
    }

    // ���b�Z�[�W���擾����
    public string GetDebugMessage()
    {
        message = "";

        //���̍s�ŕʃX�N���v�g��message���Ăяo��
        //debugText.text = onoff.message;

        // MessageWindow�̃e�L�X�g���N���A����
        //messageWindow.ClearText(); 

        return message;
    }

    public void ClearText()
    {
        // GameMgr��case���ς�������Ƀe�L�X�g���N���A����
        debugText.text = "";
    }
}
