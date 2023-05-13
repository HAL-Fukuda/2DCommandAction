using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisableUIForTag : MonoBehaviour
{
    public string Enemy;

    void Start()
    {
        Invoke("DelayedStart", 0.1f);
    }

    void DelayedStart()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(Enemy);
        foreach (GameObject objectWithTag in objectsWithTag)
        {
            // 子要素にあるUI要素を取得
            Slider[] sliders = objectWithTag.GetComponentsInChildren<Slider>();

            // 取得したUI要素を非アクティブ化
            foreach (Slider slider in sliders)
            {
                slider.interactable = false;
                //slider.gameObject.SetActive(false);
            }
        }
    }
}
