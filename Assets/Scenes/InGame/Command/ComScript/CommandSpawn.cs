using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandSpawn : MonoBehaviour
{
    public GameObject[] objectPrefabs; // 生成するオブジェクトのプレハブの配列
    public Transform spawnPoint; // スポーンポイントのTransform
    public float respawnTime = 5f; // 再生成の間隔

    private GameObject spawnedObject; // 生成されたオブジェクトの参照
    private float elapsedTime; // 経過時間

    private void Start()
    {
        SpawnObject();
        elapsedTime = 0f;
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
        if (spawnedObject == null)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= respawnTime)
            {
                SpawnObject();
                elapsedTime = 0f;
            }
        }
    }
}
