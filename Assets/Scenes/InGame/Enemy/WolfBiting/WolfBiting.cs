using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings WBUpperSettings;
    public AttackSettings WBUnderSettings;

    private Vector3 WBUpperPosition;     // �U�������ʒu
    private Vector3 WBUnderPosition;

    private GameObject WBobjUpper;
    private GameObject WBobjUnder;

    private WBCollision wbCollision;

    private bool WBflg = true;

    void GetPlayerPositionToWB()
    {
        // �Q�[���I�u�W�F�N�g��Transform�R���|�[�l���g���擾����
        //Transform myObjectTransform = player1.GetComponent<Transform>();

        GameObject PlayerObject = GameObject.Find("Player");

        // �U������̃X�|�[���ʒu�ݒ�
        WBUpperPosition = PlayerObject.transform.position;
        WBUpperPosition.y += 3.0f;
        WBUpperPosition.z = 0.0f;

        WBUnderPosition = PlayerObject.transform.position;
        WBUnderPosition.y -= 2.0f;
        WBUnderPosition.z = 0.0f;

        //Debug.Log(WBUpperPosition);
    }

    void BitingTooth()
    {
        WBobjUpper.transform.DOMove(new Vector3(WBUpperPosition.x, WBUpperPosition.y - 2, 0), 0.2f);
        WBobjUnder.transform.DOMove(new Vector3(WBUnderPosition.x, WBUnderPosition.y + 2, 0), 0.2f);

        // �����蔻����̒����p�A����s�����Ȃ���΂��̂܂܏���
        //wbCollision.GetComponent<WBCollision>().ToggleCollider(true);

        Invoke("WBobjDestroy", 0.5f);
    }

    void WBobjDestroy()
    {
        //wbCollision.GetComponent<WBCollision>().ToggleCollider(false);
        Destroy(WBobjUpper);
        Destroy(WBobjUnder);
    }

    void WBflgTrue()
    {
        WBflg = true;
    }

    public void WolfBiting()
    {

        if (WBflg)
        {

            GetPlayerPositionToWB();

            spawnPos = new Vector3(WBUpperPosition.x, WBUpperPosition.y, 0.0f);
            WBobjUpper = Instantiate(WBUpperSettings.prefab, spawnPos, Quaternion.identity);

            spawnPos = new Vector3(WBUnderPosition.x, WBUnderPosition.y, 0.0f);
            WBobjUnder = Instantiate(WBUnderSettings.prefab, spawnPos, Quaternion.identity);

            Invoke("BitingTooth", 1.0f);

            WBflg = false;
            Invoke("WBflgTrue", WBUpperSettings.spawnInterval + WBUnderSettings.spawnInterval);
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
