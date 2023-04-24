using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameMgr;

public partial class CommandMgr : MonoBehaviour
{
    [SerializeField] private GameObject attackPrefab;  //��������PreFab
    [SerializeField] private GameObject healPrefab;  //��������PreFab
    [SerializeField] private GameObject defencePrefab;  //��������PreFab
    [SerializeField] private GameObject BigPrefab;  //��������PreFab
    [SerializeField] private Transform rangeA;         //��������͈�A
    [SerializeField] private Transform rangeB;         //��������͈�B
    [SerializeField] private int num;                  //���������

    private float randomPosX, randomPosY, randomPosZ;
    private int number;

    public float dropInterval = 10.0f; // �R�}���h�������Ă���Ԋu
    private float dropTimer;

    public enum DropMode
    {
        ModeRapid,
        ModeAll
    }

    public DropMode dropMode;  //�v���_�E���p

    public void CommandDropInitialize()
    {
        dropTimer = 0.0f; // �^�C�}�[���Z�b�g
    }
    public void CommandDropUpdate()
    {
        dropTimer += Time.deltaTime;

        // ��莞�Ԗ��ɃR�}���h�������Ă���
        if (dropTimer >= dropInterval)
        {
            DropAll();
            dropTimer = 0.0f;
        }
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
            number = Random.Range(0, 11);

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
            else if (number == 10)
            {
                CreateBigCommand();
            }

            //�҂�����
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void DropAll()
    {
        for (int i = 0; i < num; i++)
        {
            number = Random.Range(0, 11);

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
            else if (number == 10)
            {
                CreateBigCommand();
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

    void CreateBigCommand()
    {
        Instantiate(BigPrefab, new Vector3(randomPosX, randomPosY, randomPosZ), BigPrefab.transform.rotation);
    }
}
