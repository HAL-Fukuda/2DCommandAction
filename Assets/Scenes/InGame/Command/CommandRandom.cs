using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandRandom : MonoBehaviour
{
    public GameObject[] objectPrefabs; // ��������I�u�W�F�N�g�̃v���n�u�̃��X�g
    public Transform spawnPoint; // �X�|�[���|�C���g��Transform
    public int numberOfObjects = 5; // ��������I�u�W�F�N�g�̐�

    private GameObject[] spawnedObjects; // �������ꂽ�I�u�W�F�N�g�̔z��

    private void Start()
    {
        spawnedObjects = new GameObject[numberOfObjects];
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        // �X�|�[���|�C���g�͈̔͂��擾
        Vector3 spawnPointPosition = spawnPoint.position;
        Vector3 spawnPointScale = spawnPoint.localScale;
        float halfWidth = spawnPointScale.x * 0.5f;

        for (int i = 0; i < numberOfObjects; i++)
        {
            // �����_����X���W���v�Z
            float randomX = Random.Range(spawnPointPosition.x - halfWidth, spawnPointPosition.x + halfWidth);

            // �����_���ȃv���n�u��I��
            GameObject randomPrefab = objectPrefabs[Random.Range(0, objectPrefabs.Length)];

            // �I�u�W�F�N�g�𐶐����A�����_���Ȉʒu�ɔz�u
            spawnedObjects[i] = Instantiate(randomPrefab, new Vector3(randomX, spawnPointPosition.y, spawnPointPosition.z), Quaternion.identity);
        }
    }

    private void Update()
    {
        // �j�����ꂽ�I�u�W�F�N�g���Đ���
        for (int i = 0; i < spawnedObjects.Length; i++)
        {
            if (spawnedObjects[i] == null)
            {
                // �����_���ȃv���n�u��I��
                GameObject randomPrefab = objectPrefabs[Random.Range(0, objectPrefabs.Length)];

                // �����_����X���W���v�Z
                float randomX = Random.Range(spawnPoint.position.x - (spawnPoint.localScale.x * 0.5f), spawnPoint.position.x + (spawnPoint.localScale.x * 0.5f));

                // �I�u�W�F�N�g���Đ������A�����_���Ȉʒu�ɔz�u
                spawnedObjects[i] = Instantiate(randomPrefab, new Vector3(randomX, spawnPoint.position.y, spawnPoint.position.z), Quaternion.identity);
            }
        }
    }
}