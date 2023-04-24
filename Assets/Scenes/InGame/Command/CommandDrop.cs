using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameMgr;

public partial class CommandMgr : MonoBehaviour
{
    [SerializeField] private GameObject attackPrefab;  //生成するPreFab
    [SerializeField] private GameObject healPrefab;  //生成するPreFab
    [SerializeField] private GameObject defencePrefab;  //生成するPreFab
    [SerializeField] private GameObject BigPrefab;  //生成するPreFab
    [SerializeField] private Transform rangeA;         //生成する範囲A
    [SerializeField] private Transform rangeB;         //生成する範囲B
    [SerializeField] private int num;                  //生成する個数

    private float randomPosX, randomPosY, randomPosZ;
    private int number;

    public float dropInterval = 10.0f; // コマンドが落ちてくる間隔
    private float dropTimer;

    public enum DropMode
    {
        ModeRapid,
        ModeAll
    }

    public DropMode dropMode;  //プルダウン用

    public void CommandDropInitialize()
    {
        dropTimer = 0.0f; // タイマーリセット
    }
    public void CommandDropUpdate()
    {
        dropTimer += Time.deltaTime;

        // 一定時間毎にコマンドが落ちてくる
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

            //待ち時間
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
