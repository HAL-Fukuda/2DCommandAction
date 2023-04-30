using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Command : MonoBehaviour
{
    public GameObject shield;
    private GameObject player;

    bool shealdOnFlg = false;

    public string defenceMessage = "";

    private GameObject lifeManager;

    private void ShieldInitialize()
    {
        lifeManager = GameObject.Find("Life");
        player = GameObject.Find("Player");
    }

    public void ShealdAction()
    {
        ShieldInitialize();
        ShealdActive();
    }

    void ShealdActive()
    {
        Instantiate(shield);

        MessageWindow.Instance.SetDebugMessage(defenceMessage);

        lifeManager.GetComponent<LifeManager>().InvincibilityOn(); // –³“Gon
    }
}