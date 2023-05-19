using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandSpawn : MonoBehaviour
{
    public GameObject objectPrefab; // 生成するオブジェクトのプレハブ
    public Transform spawnPoint; // スポーンポイントのTransform

    private GameObject spawnedObject; // 生成されたオブジェクトの参照

    private void Start()
    {
        SpawnObject();
    }

    private void SpawnObject()
    {
        // スポーンポイントの位置にオブジェクトを生成
        spawnedObject = Instantiate(objectPrefab, spawnPoint.position, Quaternion.identity);
    }

    private void Update()
    {
        // オブジェクトが破棄されたら再生成
        if (spawnedObject == null)
        {
            SpawnObject();
        }
    }
}
