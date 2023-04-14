using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings ClubBeatingSettings;
    private Vector3 CBPosition;     // �U�������ʒu
    private Rigidbody2D CBrgd;

    private GameObject CBobj;

    void GetPlayerPositionToCB()
    {
        // �Q�[���I�u�W�F�N�g��Transform�R���|�[�l���g���擾����
        Transform myObjectTransform = player1.GetComponent<Transform>();

        CBPosition = myObjectTransform.position;
        CBPosition.y = 6.0f;
        CBPosition.z = 0.0f;
        Debug.Log(CBPosition);
    }

    void CBobjDestroy()
    {
        Destroy(CBobj);
    }

    void CBobjBeating()
    {
        CBrgd.AddForce(new Vector3(0.0f, -1.0f, 0.0f) * 1000.0f);  // �������ɗ͂�������
    }

    public void ClubBeating()
    {
        GetPlayerPositionToCB();

        spawnPos = new Vector3(CBPosition.x, CBPosition.y, 0.0f);
        CBobj = Instantiate(ClubBeatingSettings.prefab, spawnPos, Quaternion.identity);
        CBrgd = CBobj.GetComponent<Rigidbody2D>();

        // 
        CBobj.transform.DOPath(
    path:        new Vector3[] { new Vector3(CBPosition.x + 2, CBPosition.y + 0.3f, 0),
                                 new Vector3(CBPosition.x + 2, CBPosition.y - 0.3f, 0),
                                 new Vector3(CBPosition.x - 2, CBPosition.y + 0.3f, 0),
                                 new Vector3(CBPosition.x - 2, CBPosition.y - 0.3f, 0),
                                 new Vector3(CBPosition.x, CBPosition.y, 0)}, //�ړ�����|�C���g
    duration:    3f, //�ړ�����
    pathType:    PathType.CatmullRom //�ړ�����p�X�̎��
    ).OnComplete(CBobjBeating);


        Invoke("CBobjDestroy", 3.5f);   // ���b��ɃI�u�W�F�N�g������
    }


    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.B))
        //{
        //    ClubBeating();
        //}
    }
}
