using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorsorController : MonoBehaviour
{
    private static Vector3[] children;
    private float beforeAxis;

    private int index = 0;
    private int maxIndex;

    public AudioClip moveSE;

    void Awake()
    {
        // 変数初期化
        index = 0;

        // 子要素の数を取得
        maxIndex = transform.childCount;

        // 子要素を格納する配列を初期化する
        children = new Vector3[maxIndex];

        // 子要素を配列に格納していく
        for (int i = 0; i < maxIndex; i++)
        {
            Transform child = transform.GetChild(i);
            children[i] = child.transform.position;
        }

        // 0番目の子要素の位置に初期化
        transform.position = children[0];
    }

    void Update()
    {
        float Axis = Input.GetAxisRaw("Vertical");

        // キーが押されると次の座標に移動
        if (Input.GetKeyDown(KeyCode.W) || (Axis < 0 && beforeAxis == 0.0f))
        {
            PlayMoveSE();
            NextIndex();
        }
        if (Input.GetKeyDown(KeyCode.S) || (Axis > 0 && beforeAxis == 0.0f))
        {
            PlayMoveSE();
            BackIndex();
        }

        beforeAxis = Axis;
    }

    void NextIndex()
    {
        index++;

        if (index >= maxIndex)
        {
            index = 0;
        }
        transform.position = children[index];
    }
    void BackIndex()
    {
        index--;

        if (index < 0)
        {
            index = maxIndex - 1;
        }
        transform.position = children[index];
    }

    void PlayMoveSE()
    {
        AudioSource.PlayClipAtPoint(moveSE, new Vector3(0, 2, -10));
    }

    public int GetIndex()
    {
        return index;
    }
}
