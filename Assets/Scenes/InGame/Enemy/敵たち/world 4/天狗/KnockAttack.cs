using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings KnockAttackSettings;
    private Vector3 KAPosition;     // �U�������ʒu
    private Rigidbody2D KArgd;

    private GameObject KAobj;

    private bool KAflg = true;

    void GetPlayerPositionToKA()
    {
        GameObject PlayerObject = GameObject.Find("Player");

        KAPosition = PlayerObject.transform.position;
        KAPosition.y = 6.0f;
        KAPosition.z = 0.0f;
    }

    void KAobjDestroy()
    {
        Destroy(KAobj);
    }

    void KAflgTrue()
    {
        KAflg = true;
    }

    void KAobjBeating()
    {
        KArgd.AddForce(new Vector3(0.0f, -1.0f, 0.0f) * 1000.0f);  // �������ɗ͂�������
    }

    public void KnockAttack()
    {
        if (KAflg)
        {
            KnockAttackSettings.timer = 0f;

            GetPlayerPositionToKA();

            spawnPos = new Vector3(KAPosition.x, KAPosition.y, 0.0f);
            KAobj = Instantiate(KnockAttackSettings.prefab, spawnPos, Quaternion.identity);
            KArgd = KAobj.GetComponent<Rigidbody2D>();

            KAobj.transform.DOPath(
            path: new Vector3[] { new Vector3(KAPosition.x + 2, KAPosition.y + 0.3f, 0),
                                 new Vector3(KAPosition.x + 2, KAPosition.y - 0.3f, 0),
                                 new Vector3(KAPosition.x - 2, KAPosition.y + 0.3f, 0),
                                 new Vector3(KAPosition.x - 2, KAPosition.y - 0.3f, 0),
                                 new Vector3(KAPosition.x, KAPosition.y, 0)}, //�ړ�����|�C���g
            duration: 3f, //�ړ�����
            pathType: PathType.CatmullRom //�ړ�����p�X�̎��
            ).OnComplete(KAobjBeating);


            Invoke("KAobjDestroy", 3.5f);   // ���b��ɃI�u�W�F�N�g������

            KAflg = false;
            Invoke("KAflgTrue", KnockAttackSettings.spawnInterval);
        }
    }
}
