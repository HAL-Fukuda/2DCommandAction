using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandDrop : MonoBehaviour
{
    [SerializeField] private GameObject createPrefab;  //��������PreFab
    [SerializeField] private Transform rangeA;         //��������͈�A
    [SerializeField] private Transform rangeB;         //��������͈�B
    [SerializeField] private int num;                  //���������

    public enum DropMode
    {
        ModeRapid,
        ModeAll
    }

    public DropMode dropMode;  //�v���_�E���p

    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            switch (dropMode)
            {
                case DropMode.ModeRapid:   //�A��
                    DropRapid();
                    break;

                case DropMode.ModeAll:     //��C��
                    DropAll();
                    break;
            }
        }
       

    }

    void DropRapid()
    {
        StartCoroutine(CreateCommand());
    }

    IEnumerator CreateCommand()
    {
        for (int i = 0; i < num; i++)
        {
            //�����_���ȍ��W���쐬
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            float y = Random.Range(rangeA.position.y, rangeB.position.y);
            float z = Random.Range(rangeA.position.z, rangeB.position.z);

            //PreFab�𐶐�
            Instantiate(createPrefab, new Vector3(x, y, z), createPrefab.transform.rotation);

            //�҂�����
            yield return new WaitForSeconds(0.5f);
        }
    }

    void DropAll()
    {
        for (int i = 0; i < num; i++)
        {
            //�����_���ȍ��W���쐬
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            float y = Random.Range(rangeA.position.y, rangeB.position.y);
            float z = Random.Range(rangeA.position.z, rangeB.position.z);

            //PreFab�𐶐�
            Instantiate(createPrefab, new Vector3(x, y, z), createPrefab.transform.rotation);
        }
    }
}
