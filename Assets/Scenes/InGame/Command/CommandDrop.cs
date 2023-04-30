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
    [SerializeField] private int num;                  //���������

    [SerializeField] private Vector3 positionA;  // ��������Œ�ʒuA
    [SerializeField] private Vector3 positionB;  // ��������Œ�ʒuB
    [SerializeField] private Vector3 positionC;  // ��������Œ�ʒuC

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
                    //DropAtFixedPositions();
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
    
    public void DropAll(int num)
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
        //rangeA��Scale�͈̔͂��烉���_����
        float rangeSize = rangeA.localScale.x;
        float halfRangeSize = rangeSize / 2.0f;
        float leftBoundary = rangeA.position.x - halfRangeSize;
        float rightBoundary = rangeA.position.x + halfRangeSize;

        randomPosX = Random.Range(leftBoundary, rightBoundary);
        randomPosY = rangeA.position.y;
        randomPosZ = rangeA.position.z;
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

    public void DropAtFixedPositions()//�w�肵���ʒu�ɃR�}���h���~�点��(����O��)
    {
        for (int i = 0; i < num; i++)
        {
            int number = Random.Range(0, 11);

            Vector3 position = Vector3.zero;
            switch (i % 3) // 3�̌Œ�ʒu���z����
            {
                case 0:
                    position = positionA;
                    break;
                case 1:
                    position = positionB;
                    break;
                case 2:
                    position = positionC;
                    break;
            }

            if (0 <= number && number <= 7)
            {
                Instantiate(attackPrefab, position, attackPrefab.transform.rotation);
            }
            else if (number == 8)
            {
                Instantiate(healPrefab, position, healPrefab.transform.rotation);
            }
            else if (number == 9)
            {
                Instantiate(defencePrefab, position, defencePrefab.transform.rotation);
            }
            else if (number == 10)
            {
                Instantiate(BigPrefab, position, BigPrefab.transform.rotation);
            }
        }
    }

}
