using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings FirePunchSettings;
    private Vector3 FPPosition;     // �U�������ʒu
    private Rigidbody2D FPrgd;

    private GameObject FPobj;

    private bool FPflg = true;

    public bool PunchIsFire;
    private float FPTweak = 0.0f;


    void GetPlayerPositionToFP()
    {
        // �Q�[���I�u�W�F�N�g��Transform�R���|�[�l���g���擾����
        //Transform myObjectTransform = player1.GetComponent<Transform>();

        GameObject PlayerObject = GameObject.Find("Player");

        FPPosition = PlayerObject.transform.position;
        FPPosition.y = 6.0f;
        FPPosition.z = 0.0f;
        //Debug.Log(FPPosition);
    }

    void FPobjDestroy()
    {
        Destroy(FPobj);
    }

    void FPflgTrue()
    {
        FPflg = true;
    }

    void FPobjBeating()
    {
        FPrgd.AddForce(new Vector3(0.0f, -1.0f, 0.0f) * 1000.0f);  // �������ɗ͂�������

        Invoke("FPobjDestroy", 0.5f);   // ���b��ɃI�u�W�F�N�g������
        Invoke("FPflgTrue", FirePunchSettings.spawnInterval);
    }

    public void FirePunch()
    {
        if (PunchIsFire)
        {
            FPTweak = 1.5f;
        }
        else
        {
            FPTweak = -1.3f;
        }

        if (FPflg)
        {

            GetPlayerPositionToFP();

            spawnPos = new Vector3(FPPosition.x, FPPosition.y, 0.0f);
            FPobj = Instantiate(FirePunchSettings.prefab, spawnPos, Quaternion.identity);

            // ���W�b�g�{�f�B�Ԃ�����
            FPrgd = FPobj.GetComponent<Rigidbody2D>();


            // �p���`�̗\���̓���
            FPobj.transform.DOMove(new Vector3(FPPosition.x + 2, FPPosition.y + 0.3f, 0), 0.3f).SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    GetPlayerPositionToFP();

                    FPobj.transform.DOMove(new Vector3(FPPosition.x + 2, FPPosition.y - 0.3f, 0), 0.3f).SetEase(Ease.Linear)
                        .OnComplete(() =>
                         {
                            GetPlayerPositionToFP();

                             FPobj.transform.DOMove(new Vector3(FPPosition.x - 2, FPPosition.y + 0.3f, 0), 0.3f).SetEase(Ease.Linear)
                                   .OnComplete(() =>
                                {
                                 GetPlayerPositionToFP();

                                    FPobj.transform.DOMove(new Vector3(FPPosition.x - 2, FPPosition.y - 0.3f, 0), 0.3f).SetEase(Ease.Linear)
                                                .OnComplete(() =>
                                            {
                                                 GetPlayerPositionToFP();

                                                FPobj.transform.DOMove(new Vector3(FPPosition.x + FPTweak, FPPosition.y, 0), 0.3f).SetEase(Ease.Linear)
                                                    .OnComplete(FPobjBeating);
                                            });
                                });
                         });
                });

            FPflg = false;
            
        }
    }


}
