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
        // �ϐ�������
        index = 0;

        // �q�v�f�̐����擾
        maxIndex = transform.childCount;

        // �q�v�f���i�[����z�������������
        children = new Vector3[maxIndex];

        // �q�v�f��z��Ɋi�[���Ă���
        for (int i = 0; i < maxIndex; i++)
        {
            Transform child = transform.GetChild(i);
            children[i] = child.transform.position;
        }

        // 0�Ԗڂ̎q�v�f�̈ʒu�ɏ�����
        transform.position = children[0];
    }

    void Update()
    {
        float Axis = Input.GetAxisRaw("Vertical");

        // �L�[���������Ǝ��̍��W�Ɉړ�
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
