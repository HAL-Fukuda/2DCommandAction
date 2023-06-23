using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private Menu menu;

    private void Start()
    {
        GameObject menuObject = GameObject.Find("Menu");

        menu = menuObject.GetComponent<Menu>();
    }

    public void OnRestartButtonClicked()
    {
        menu.Resume();
        // �X�e�[�W�������[�h����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
