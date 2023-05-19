using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings GBUpperSettings;
    public AttackSettings GBUnderSettings;

    private Vector3 GBUpperPosition;     // �U�������ʒu
    private Vector3 GBUnderPosition;

    private GameObject GBobjUpper;
    private GameObject GBobjUnder;

    private WBCollision gbCollision;

    private bool GBflg = true;

    void GetPlayerPositionToGB()
    {
        // �Q�[���I�u�W�F�N�g��Transform�R���|�[�l���g���擾����
        //Transform myObjectTransform = player1.GetComponent<Transform>();

        GameObject PlayerObject = GameObject.Find("Player");

        // �U������̃X�|�[���ʒu�ݒ�
        GBUpperPosition = PlayerObject.transform.position;
        GBUpperPosition.y += 3.0f;
        GBUpperPosition.z = 0.0f;

        GBUnderPosition = PlayerObject.transform.position;
        GBUnderPosition.y -= 2.0f;
        GBUnderPosition.z = 0.0f;

        //Debug.Log(WBUpperPosition);
    }

    void GBitingTooth()
    {
        GBobjUpper.transform.DOMove(new Vector3(GBUpperPosition.x, GBUpperPosition.y - 2, 0), 0.2f);
        GBobjUnder.transform.DOMove(new Vector3(GBUnderPosition.x, GBUnderPosition.y + 2, 0), 0.2f);

        // �����蔻����̒����p�A����s�����Ȃ���΂��̂܂܏���
        //wbCollision.GetComponent<WBCollision>().ToggleCollider(true);

        Invoke("GBobjDestroy", 0.5f);
    }

    void GBobjDestroy()
    {
        //wbCollision.GetComponent<WBCollision>().ToggleCollider(false);
        Destroy(GBobjUpper);
        Destroy(GBobjUnder);
    }

    void GBflgTrue()
    {
        GBflg = true;
    }

    public void GenbuBiting()
    {

        if (GBflg)
        {

            GetPlayerPositionToGB();

            spawnPos = new Vector3(GBUpperPosition.x, GBUpperPosition.y, 0.0f);
            GBobjUpper = Instantiate(GBUpperSettings.prefab, spawnPos, Quaternion.identity);

            spawnPos = new Vector3(GBUnderPosition.x, GBUnderPosition.y, 0.0f);
            GBobjUnder = Instantiate(GBUnderSettings.prefab, spawnPos, Quaternion.identity);

            Invoke("GBitingTooth", 0.2f);

            GBflg = false;
            Invoke("GBflgTrue", GBUpperSettings.spawnInterval + GBUnderSettings.spawnInterval);
        }
    }


    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.B))
    //    {
    //        WolfBiting();
    //    }
    //}
}