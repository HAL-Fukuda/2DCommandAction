using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    //[System.Serializable]
    //public struct AttackSettings
    //{
    //    public GameObject prefab;
    //    public float spawnInterval;
    //    public float life;
    //    [SerializeField][Header("������Ȃ���")] public float timer;

    //    public AttackSettings(GameObject prefab, float spawnInterval, float life)
    //    {
    //        this.prefab = prefab;
    //        this.spawnInterval = spawnInterval;
    //        this.life = life;
    //        this.timer = 0f;
    //    }
    //}

    // �v���C���[�I�u�W�F�N�g���Q�Ƃ���
    public GameObject player1;  // �v���C���[�̈ʒu�擾�p

    public AttackSettings BeamComingAttackSettings;
    public AttackSettings SatelliteAttackSettings;

    // �I�u�W�F�N�g�̈ʒu���擾����
    private Vector3 objectPosition;
    private Vector3 spawnPos;

    void GetPlayerPositionX()
    {
        // �Q�[���I�u�W�F�N�g��Transform�R���|�[�l���g���擾����
        Transform myObjectTransform = player1.GetComponent<Transform>();

        objectPosition = myObjectTransform.position;
    }

    void premonition()
    {
        // �v���C���[�̈ʒu�ɗ\������
        spawnPos = new Vector3(objectPosition.x, 0f, 0f);
        GameObject obj = Instantiate(BeamComingAttackSettings.prefab, spawnPos, Quaternion.identity);
        obj.transform.DOMoveY(
                0, //�ړ���
                BeamComingAttackSettings.life // ���o����
            ).OnComplete(() =>
            {
                Destroy(obj);
                RealBeam();
            });
    }

    void RealBeam()
    {
        // �v���C���[�̈ʒu�Ƀr�[������
        //Vector3 spawnPos = new Vector3(objectPosition.x, 0f, 0f);
        GameObject obj1 = Instantiate(SatelliteAttackSettings.prefab, spawnPos, Quaternion.identity);
        obj1.transform.DOMoveY(
                0, //�ړ���
                SatelliteAttackSettings.life // ���o����
            ).OnComplete(() =>
            {
                Destroy(obj1);
            });
    }

    void SatelliteBeam()
    {
        GetPlayerPositionX();

        premonition();

        //Debug.Log(objectPosition);
    }


    // Start is called before the first frame update


    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.B))
    //    {
    //        SatelliteBeam();
    //    }
    //}
}
