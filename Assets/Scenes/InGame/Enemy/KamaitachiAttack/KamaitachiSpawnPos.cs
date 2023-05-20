using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamaitachiSpawnPos : MonoBehaviour
{
    public GameObject kamaitachiPrefab;
    public int maxSpawnNum;  //最大生成量

    private float timer;  //経過時間
    private int spawnNum;  //生成する回数
    private Vector3 spawnPos;  //オブジェクトの生成位置

    void Start()
    {
        timer = 0f;
        spawnNum = 0;
        spawnPos = this.transform.position;
    }
    
    void Update()
    {
        timer += Time.deltaTime;

        //一定時間後に生成
        if (timer >= 3.5f)
        {
            if (spawnNum <= maxSpawnNum)
            {
                //かまいたちPrefab生成
                KamaitachiPrefabSpawn();
            }

            spawnNum++;
        }

        //一定時間後に削除
        if (timer >= 5.5f)
        {
            Destroy(this.gameObject);
        }
    }

    //オブジェクト生成
    void KamaitachiPrefabSpawn()
    {
        GameObject kamaitachi = Instantiate(kamaitachiPrefab, spawnPos, Quaternion.identity);
    }
}
