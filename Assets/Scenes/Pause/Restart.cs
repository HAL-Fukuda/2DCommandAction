using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private Menu menu;
    public float fadetime;

    private void Start()
    {
        GameObject menuObject = GameObject.Find("Menu");

        menu = menuObject.GetComponent<Menu>();
    }

    public void OnRestartButtonClicked()
    {
        menu.Resume();
        // ステージをリロードする
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        FadeManager.Instance.LoadScene(SceneManager.GetActiveScene().name, fadetime);
    }
}
