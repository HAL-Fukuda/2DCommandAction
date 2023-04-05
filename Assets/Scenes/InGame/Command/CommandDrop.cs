using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CommandMgr : MonoBehaviour
{
    [SerializeField] private GameObject attackPrefab;  //生成するPreFab
    [SerializeField] private GameObject healPrefab;  //生成するPreFab
    [SerializeField] private GameObject defencePrefab;  //生成するPreFab
    [SerializeField] private Transform rangeA;         //生成する範囲A
    [SerializeField] private Transform rangeB;         //生成する範囲B
    [SerializeField] private int num;                  //生成する個数

    private float randomPosX, randomPosY, randomPosZ;
    private int number;

    public enum DropMode
    {
        ModeRapid,
        ModeAll
    }

    public DropMode dropMode;  //プルダウン用

    void CommandDropInitialize()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            switch (dropMode)
            {
                case DropMode.ModeRapid:   //連続
                    DropRapid();
                    break;

                case DropMode.ModeAll:     //一気に
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

            //待ち時間
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
