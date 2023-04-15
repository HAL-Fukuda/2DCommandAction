using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings ClubSwingSettings;
    private Vector3 CSPosition;     // �U�������ʒu
    private Rigidbody2D CSrgd;

    public float SwingSpeedSeconds;

    private GameObject CSobj;

    private GameObject csCollision;


    void GetPlayerPositionToCS()
    {
        // �Q�[���I�u�W�F�N�g��Transform�R���|�[�l���g���擾����
        Transform myObjectTransform = player1.GetComponent<Transform>();

        // �U������̃X�|�[���ʒu�ݒ�
        CSPosition = myObjectTransform.position;

        if (CSPosition.x < 0)
        {
            CSPosition.x = 10.0f;
        }
        else
        {
            CSPosition.x = -10.0f;
        }
        CSPosition.y += 1.0f;
        CSPosition.z = 0.0f;
        //Debug.Log(CSPosition);
    }

    void CSobjSwing()
    {
        if (CSPosition.x < 0)   // �U�������N���̎�
        {
            csCollision.GetComponent<CSCollision>().SwingSoundPlay();
            CSobj.transform.DOMove(new Vector3(15, CSPosition.y, 0), SwingSpeedSeconds)
                .OnComplete(CSobjDestroy);
            
        }
        else
        {
            csCollision.GetComponent<CSCollision>().SwingSoundPlay();
            CSobj.transform.DOMove(new Vector3(-15, CSPosition.y, 0), SwingSpeedSeconds)
                .OnComplete(CSobjDestroy);
            
        }
    }

    void CSobjDestroy()
    {
        Destroy(CSobj);
    }

    void ClubSwing()
    {
        GetPlayerPositionToCS();
        spawnPos = new Vector3(CSPosition.x, CSPosition.y, 0.0f);
        CSobj = Instantiate(ClubSwingSettings.prefab, spawnPos, Quaternion.identity);
        CSrgd = CSobj.GetComponent<Rigidbody2D>();

        csCollision = GameObject.Find("ClubSwing(Clone)");

        CSobj.transform.DOPath(
    path: new Vector3[] {        new Vector3(CSPosition.x + 0.3f, CSPosition.y + 2, 0),
                                 new Vector3(CSPosition.x - 0.3f, CSPosition.y + 2, 0),
                                 new Vector3(CSPosition.x + 0.3f, CSPosition.y - 2, 0),
                                 new Vector3(CSPosition.x - 0.3f, CSPosition.y - 2, 0),
                                 new Vector3(CSPosition.x, CSPosition.y, 0)}, //�ړ�����|�C���g
    duration: 3f, //�ړ�����
    pathType: PathType.CatmullRom //�ړ�����p�X�̎��
    ).OnComplete(CSobjSwing);

        //Invoke("CSobjDestroy", 3.5f);   // ���b��ɃI�u�W�F�N�g������
    }


    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.B))
    //    {
    //        ClubSwing();
    //    }
    //}
}
