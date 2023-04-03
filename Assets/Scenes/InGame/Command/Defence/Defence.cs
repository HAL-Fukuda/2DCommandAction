using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Command : MonoBehaviour
{
    public GameObject shield;
    private GameObject shieldInstance;
    private GameObject player;

    bool shealdOnFlg = false;

    public string defenceMessage = "";
    
    //// LifeManager�A�^�b�`���Ă�
    private GameObject lifeManager;

    private void ShieldInitialize()
    {
        lifeManager = GameObject.Find("Life");
        player = GameObject.Find("Player");
    }

    public void ShealdAction()
    {
        ShieldInitialize();

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

            Debug.Log("debug");

            shealdOnFlg = true;
            //shield.SetActive(true);     // �V�[���h�W�J
            shieldInstance = Instantiate(shield);

            MessageWindow.Instance.SetDebugMessage(defenceMessage);

            lifeManager.GetComponent<LifeManager>().InvincibilityOn(); // ���Gon
        }
    }

    void ShealdNotActive()
    {
        //shield.SetActive(false);
        Destroy(shieldInstance);

        shealdOnFlg = false;

        lifeManager.GetComponent<LifeManager>().InvincibilityOff();    // ���Goff
    }

    //private void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.B))
    //    {
    //        ShealdAction();
    //    }
    //}

}