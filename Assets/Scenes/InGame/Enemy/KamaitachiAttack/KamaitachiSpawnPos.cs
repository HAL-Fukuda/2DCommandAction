using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamaitachiSpawnPos : MonoBehaviour
{
    public GameObject kamaitachiPrefab;
    public int maxSpawnNum;  //�ő吶����

    private float timer;  //�o�ߎ���
    private int spawnNum;  //���������
    private Vector3 spawnPos;  //�I�u�W�F�N�g�̐����ʒu

    void Start()
    {
        timer = 0f;
        spawnNum = 0;
        spawnPos = this.transform.position;
    }
    
    void Update()
    {
        timer += Time.deltaTime;

        //��莞�Ԍ�ɐ���
        if (timer >= 3.5f)
        {
            if (spawnNum <= maxSpawnNum)
            {
                //���܂�����Prefab����
                KamaitachiPrefabSpawn();
            }

            spawnNum++;
        }

        //��莞�Ԍ�ɍ폜
        if (timer >= 5.5f)
        {
            Destroy(this.gameObject);
        }
    }

    //�I�u�W�F�N�g����
    void KamaitachiPrefabSpawn()
    {
        GameObject kamaitachi = Instantiate(kamaitachiPrefab, spawnPos, Quaternion.identity);
    }
}
