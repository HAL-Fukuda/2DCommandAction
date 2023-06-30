using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSwitcher : MonoBehaviour
{
    public Sprite[] Images;
    private int currentIdx = -1;
    private Sprite originalImage;

    // Start is called before the first frame update
    void Start()
    {
        // 現在セットされている画像取得
        originalImage = GetComponent<SpriteRenderer>().sprite;
    }

   /* private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SwitchSprite();
            //SwitchSprite(0);
        }
    }*/

    // スプライトの切り替え
    public void SwitchSprite(int idx) // 引数で番号を指定
    {
        currentIdx = idx;

        // 画像がNULLならエラー
        if (Images[currentIdx] == null)
        {
            Debug.Log("画像参照エラー。");
            return;
        }

        // 画像を変更
        GetComponent<SpriteRenderer>().sprite = Images[currentIdx];
    }

    public void SwitchSprite() // 連番で切り替える
    {
        currentIdx++;
        if(currentIdx >= Images.Length) // サイズを超えたら0に戻す
        {
            currentIdx = 0;
        }

        // 画像がNULLならエラー
        if (Images[currentIdx] == null)
        {
            Debug.Log("画像参照エラー。");
            return;
        }

        // 画像を変更
        GetComponent<SpriteRenderer>().sprite = Images[currentIdx];
    }

    public void DebugMode()
    {
        Debug.Log("SpriteSwitcherが呼ばれた");
    }
}
