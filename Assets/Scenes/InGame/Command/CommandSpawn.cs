using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandSpawn : MonoBehaviour
{
    public GameObject[] objectPrefabs; // ��������I�u�W�F�N�g�̃v���n�u�̔z��
    public Transform spawnPoint; // �X�|�[���|�C���g��Transform
    public float respawnTime = 5f; // �Đ����̊Ԋu

    private GameObject spawnedObject; // �������ꂽ�I�u�W�F�N�g�̎Q��
    private float elapsedTime; // �o�ߎ���

    private void Start()
    {
        SpawnObject();
        elapsedTime = 0f;
    }

    private void SpawnObject()
    {
        // �����_���ɃI�u�W�F�N�g��I��
        int randomIndex = Random.Range(0, objectPrefabs.Length);
        GameObject selectedPrefab = objectPrefabs[randomIndex];

        // �X�|�[���|�C���g�̈ʒu�ɃI�u�W�F�N�g�𐶐�
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
