using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackStageSelect : MonoBehaviour
{
    public float fadetime;

    public string WorldSelectNumber;

    // Start is called before the first frame update
    public void BackToStageSelect()
    {
        // �X�e�[�W������
        FadeManager.Instance.LoadScene(WorldSelectNumber, fadetime);
        //SceneManager.LoadScene(stage);
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyUp(KeyCode.Escape))||(Input.GetKeyUp(KeyCode.Return))||(Input.GetKeyUp(KeyCode.Space)))
        {
            BackToStageSelect();
        }
    }
}