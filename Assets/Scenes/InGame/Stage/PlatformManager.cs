using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{

    public PlatformEffector2D platformEffector2D;

    private void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            Through();  // S�L�[�������ď������蔲����
        }
    }
    public void Through()
    {
        platformEffector2D.surfaceArc = 0;  //���̂��蔲��
        Invoke("Reset", 0.5f);  //�������Ԃ�u���Ă��蔲��������߂�
    }

    private void Reset()
    {
        platformEffector2D.surfaceArc = 120;�@// ���蔲��������߂�
    }
}
