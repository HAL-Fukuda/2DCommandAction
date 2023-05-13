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
            // �q�v�f�ɂ���UI�v�f���擾
            Slider[] sliders = objectWithTag.GetComponentsInChildren<Slider>();

            // �擾����UI�v�f���A�N�e�B�u��
            foreach (Slider slider in sliders)
            {
                slider.interactable = false;
                //slider.gameObject.SetActive(false);
            }
        }
    }
}
