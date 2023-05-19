using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandRandom : MonoBehaviour
{
    public GameObject[] objectPrefabs; // 生成するオブジェクトのプレハブのリスト
    public Transform spawnPoint; // スポーンポイントのTransform
    public int numberOfObjects = 5; // 生成するオブジェクトの数

    private GameObject[] spawnedObjects; // 生成されたオブジェクトの配列

    private void Start()
    {
        spawnedObjects = new GameObject[numberOfObjects];
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        // スポーンポイントの範囲を取得
        Vector3 spawnPointPosition = spawnPoint.position;
        Vector3 spawnPointScale = spawnPoint.localScale;
        float halfWidth = spawnPointScale.x * 0.5f;

        for (int i = 0; i < numberOfObjects; i++)
        {
            // ランダムなX座標を計算
            float randomX = Random.Range(spawnPointPosition.x - halfWidth, spawnPointPosition.x + halfWidth);

            // ランダムなプレハブを選択
            GameObject randomPrefab = objectPrefabs[Random.Range(0, objectPrefabs.Length)];

            // オブジェクトを生成し、ランダムな位置に配置
            spawnedObjects[i] = Instantiate(randomPrefab, new Vector3(randomX, spawnPointPosition.y, spawnPointPosition.z), Quaternion.identity);
        }
    }

    private void Update()
    {
        // 破棄されたオブジェクトを再生成
        for (int i = 0; i < spawnedObjects.Length; i++)
        {
            if (spawnedObjects[i] == null)
            {
                // ランダムなプレハブを選択
                GameObject randomPrefab = objectPrefabs[Random.Range(0, objectPrefabs.Length)];

                // ランダムなX座標を計算
                float randomX = Random.Range(spawnPoint.position.x - (spawnPoint.localScale.x * 0.5f), spawnPoint.position.x + (spawnPoint.localScale.x * 0.5f));

                // オブジェクトを再生成し、ランダムな位置に配置
                spawnedObjects[i] = Instantiate(randomPrefab, new Vector3(randomX, spawnPoint.position.y, spawnPoint.position.z), Quaternion.identity);
            }
        }
    }
}