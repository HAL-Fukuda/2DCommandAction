using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Command : MonoBehaviour
{
    public GameObject shield;

    bool shealdOnFlg = false;

    public string message = "";
    
    // LifeManager�A�^�b�`���Ă�
    public GameObject lifeManager;

    void ShealdAction()
    {
        if (shealdOnFlg == false)
        {
            ShealdActive();
            Invoke("ShealdNotActive", 3.0f);    // 3�b��ɃV�[���h������
        }
    }

    void ShealdActive()
    {
        if (shealdOnFlg == false)
        {
            shealdOnFlg = true;
            shield.SetActive(true);     // �V�[���h�W�J

            message = "�V�[���h�W�J���܂���";     // �R�}���h�I�����̃��b�Z�[�W
            lifeManager.GetComponent<LifeManager>().InvincibilityOn(); // ���Gon
        }
    }

    void ShealdNotActive()
    {
        shield.SetActive(false);
        shealdOnFlg = false;

        lifeManager.GetComponent<LifeManager>().InvincibilityOff();    // ���Goff
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.B))
        {
            ShealdAction();
        }
    }

}