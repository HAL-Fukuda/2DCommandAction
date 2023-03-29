using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandDrop : MonoBehaviour
{
    [SerializeField] private GameObject createPrefab;  //生成するPreFab
    [SerializeField] private Transform rangeA;         //生成する範囲A
    [SerializeField] private Transform rangeB;         //生成する範囲B
    [SerializeField] private int num;                  //生成する個数

    public enum DropMode
    {
        ModeRapid,
        ModeAll
    }

    public DropMode dropMode;  //プルダウン用

    void Start()
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
            //ランダムな座標を作成
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            float y = Random.Range(rangeA.position.y, rangeB.position.y);
            float z = Random.Range(rangeA.position.z, rangeB.position.z);

            //PreFabを生成
            Instantiate(createPrefab, new Vector3(x, y, z), createPrefab.transform.rotation);

            //待ち時間
            yield return new WaitForSeconds(0.5f);
        }
    }

    void DropAll()
    {
        for (int i = 0; i < num; i++)
        {
            //ランダムな座標を作成
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            float y = Random.Range(rangeA.position.y, rangeB.position.y);
            float z = Random.Range(rangeA.position.z, rangeB.position.z);

            //PreFabを生成
            Instantiate(createPrefab, new Vector3(x, y, z), createPrefab.transform.rotation);
        }
    }
}
