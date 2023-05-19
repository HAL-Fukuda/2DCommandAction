using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandSpawn : MonoBehaviour
{
    public GameObject[] objectPrefabs; // 生成するオブジェクトのプレハブの配列
    public Transform spawnPoint; // スポーンポイントのTransform

    private GameObject spawnedObject; // 生成されたオブジェクトの参照

    private void Start()
    {
        SpawnObject();
    }

    private void SpawnObject()
    {
        // ランダムにオブジェクトを選ぶ
        int randomIndex = Random.Range(0, objectPrefabs.Length);
        GameObject selectedPrefab = objectPrefabs[randomIndex];

        // スポーンポイントの位置にオブジェクトを生成
        spawnedObject = Instantiate(selectedPrefab, spawnPoint.position, Quaternion.identity);
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