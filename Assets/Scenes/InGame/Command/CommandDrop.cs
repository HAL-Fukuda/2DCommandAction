using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CommandMgr : MonoBehaviour
{
    [SerializeField] private GameObject attackPrefab;  //��������PreFab
    [SerializeField] private GameObject healPrefab;  //��������PreFab
    [SerializeField] private GameObject defencePrefab;  //��������PreFab
    [SerializeField] private Transform rangeA;         //��������͈�A
    [SerializeField] private Transform rangeB;         //��������͈�B
    [SerializeField] private int num;                  //���������

    private float randomPosX, randomPosY, randomPosZ;
    private int number;

    public enum DropMode
    {
        ModeRapid,
        ModeAll
    }

    public DropMode dropMode;  //�v���_�E���p

    void CommandDropInitialize()
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
            number = Random.Range(0, 10);

            CreateRandomPos();

            if (number >= 0 && number <= 7)
            {
                CreateAttackCommand();
            }
            else if (number == 8)
            {
                CreateHealCommand();
            }
            else if (number == 9)
            {
                CreateDefenceCommand();
            }

            //�҂�����
            yield return new WaitForSeconds(0.5f);
        }
    }

    void DropAll()
    {
        for (int i = 0; i < num; i++)
        {
            number = Random.Range(0, 10);

            CreateRandomPos();

            if (0 <= number && number <= 7)
            {
                CreateAttackCommand();
            }
            else if (number == 8)
            {
                CreateHealCommand();
            }
            else if (number == 9)
            {
                CreateDefenceCommand();
            }
        }
    }

    void CreateRandomPos()
    {
        randomPosX = Random.Range(rangeA.position.x, rangeB.position.x);
        randomPosY = Random.Range(rangeA.position.y, rangeB.position.y);
        randomPosZ = Random.Range(rangeA.position.z, rangeB.position.z);
    }

    void CreateAttackCommand()
    {
        Instantiate(attackPrefab, new Vector3(randomPosX, randomPosY, randomPosZ), attackPrefab.transform.rotation);
    }

    void CreateHealCommand()
    {
        Instantiate(healPrefab, new Vector3(randomPosX, randomPosY, randomPosZ), healPrefab.transform.rotation);
    }

    void CreateDefenceCommand()
    {
        Instantiate(defencePrefab, new Vector3(randomPosX, randomPosY, randomPosZ), defencePrefab.transform.rotation);
    }
}
