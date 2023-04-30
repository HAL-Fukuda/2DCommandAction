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
    [SerializeField] private int num;                  //生成する個数

    [SerializeField] private Vector3 positionA;  // 生成する固定位置A
    [SerializeField] private Vector3 positionB;  // 生成する固定位置B
    [SerializeField] private Vector3 positionC;  // 生成する固定位置C

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
        //rangeAのScaleの範囲からランダムに
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

    public void DropAtFixedPositions()//指定した位置にコマンドを降らせる(現状三つ)
    {
        for (int i = 0; i < num; i++)
        {
            int number = Random.Range(0, 11);

            Vector3 position = Vector3.zero;
            switch (i % 3) // 3つの固定位置を循環する
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
