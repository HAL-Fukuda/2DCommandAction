using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandSpawn : MonoBehaviour
{
    public GameObject objectPrefab; // ��������I�u�W�F�N�g�̃v���n�u
    public Transform spawnPoint; // �X�|�[���|�C���g��Transform

    private GameObject spawnedObject; // �������ꂽ�I�u�W�F�N�g�̎Q��

    private void Start()
    {
        SpawnObject();
    }

    private void SpawnObject()
    {
        // �X�|�[���|�C���g�̈ʒu�ɃI�u�W�F�N�g�𐶐�
        spawnedObject = Instantiate(objectPrefab, spawnPoint.position, Quaternion.identity);
    }

    private void Update()
    {
        // �I�u�W�F�N�g���j�����ꂽ��Đ���
        if (spawnedObject == null)
        {
            SpawnObject();
        }
    }
}
