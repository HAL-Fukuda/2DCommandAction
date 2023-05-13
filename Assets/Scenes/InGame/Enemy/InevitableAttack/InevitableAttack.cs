using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings InevitableAttackSettings;
    public AttackSettings OmenAttackSettings;

    // �I�u�W�F�N�g�̈ʒu���擾����
    private Vector3 IAPosition;

    public GameObject EnemyIA;

    private GameObject IAobj;
    private GameObject IAOobj;

    private Material IAmaterial;

    private bool IAflg = true;


    void GetPositionToIA()
    {
        // �Q�[���I�u�W�F�N�g��Transform�R���|�[�l���g���擾����
        //Transform myObjectTransform = EnemySS.GetComponent<Transform>();

        // ���"�G�̖��O(Clone)"�ɕς���
        GameObject EnemyObject = GameObject.FindWithTag("Enemy");

        if (EnemyObject == null)
        {
            EnemyObject = GameObject.Find("Enemy2");
        }

        IAPosition = EnemyObject.transform.position;

        IAPosition.z = 0.0f;
        //Debug.Log(IAPosition);
    }

    void IAflgTrue()
    {
        IAflg = true;
    }

    void OmenIA()
    {
        spawnPos = new Vector3(IAPosition.x, IAPosition.y, 0.0f);
        IAOobj = Instantiate(OmenAttackSettings.prefab, spawnPos, Quaternion.identity);
        IAOobj.transform.DOScale(new Vector3(0.0f, 0.0f, 0.0f), 2.0f)
            .OnComplete(() =>
            {
                Destroy(IAOobj);
                Inevitable();
            });
    }

    void Inevitable()
    {
        spawnPos = new Vector3(IAPosition.x, IAPosition.y, 0.0f);
        IAobj = Instantiate(InevitableAttackSettings.prefab, spawnPos, Quaternion.identity);

        // GameObject����ŏ���Renderer���擾����
        Renderer renderer = IAobj.GetComponent<Renderer>();

        // Renderer�����݂���ꍇ�A����Material���擾����
        if (renderer != null)
        {
            IAmaterial = renderer.material;
            // �擾����Material���g���ĉ��炩�̏������s��
        }

        IAobj.transform.DOScale(new Vector3(30.0f, 30.0f, 1.0f), 2.0f)
            .OnComplete(InvisibleIA);
    }

    void InvisibleIA()
    {
        // �����x����������ɃI�u�W�F�N�g������
        IAmaterial.DOFade(0f, 1f)
            .OnComplete(() =>
            {
                Destroy(IAobj);

                Invoke("IAflgTrue", InevitableAttackSettings.spawnInterval);
            });
    }



    public void InevitableAttack()
    {
        if (IAflg)
        {
            IAflg = false;

            GetPositionToIA();

            OmenIA();
        }
    }

  
}
