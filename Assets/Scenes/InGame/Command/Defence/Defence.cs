using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Command : MonoBehaviour
{
    public GameObject shield;

    bool shealdOnFlg = false;

    public string message = "";
    
    // LifeManagerアタッチしてね
    public GameObject lifeManager;

    void ShealdAction()
    {
        if (shealdOnFlg == false)
        {
            ShealdActive();
            Invoke("ShealdNotActive", 3.0f);    // 3秒後にシールドを消す
        }
    }

    void ShealdActive()
    {
        if (shealdOnFlg == false)
        {
            shealdOnFlg = true;
            shield.SetActive(true);     // シールド展開

            message = "シールド展開しました";     // コマンド選択時のメッセージ
            lifeManager.GetComponent<LifeManager>().InvincibilityOn(); // 無敵on
        }
    }

    void ShealdNotActive()
    {
        shield.SetActive(false);
        shealdOnFlg = false;

        lifeManager.GetComponent<LifeManager>().InvincibilityOff();    // 無敵off
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.B))
        {
            ShealdAction();
        }
    }

}