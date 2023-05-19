using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour//�N���X������
{
    public AttackSettings floorburnSettings;
    
    // public GameObject objectPrefab; // �o������I�u�W�F�N�g�̃v���n�u
    public float moveSpeed = 3f; // �I�u�W�F�N�g�̏㏸���x

    public void FloorburnAttack()
    {
        Vector3 spawnPosition = new Vector3(0f, -12f, 0f); // �o���ʒu�̐ݒ�

        // �I�u�W�F�N�g�𐶐�����
        GameObject newObject = Instantiate(floorburnSettings.Prefab, spawnPosition, Quaternion.identity);

        // ������Ɉړ�������
        Rigidbody2D rb2D = newObject.GetComponent<Rigidbody2D>();
        if (rb2D != null)
        {
            rb2D.velocity = Vector2.up * moveSpeed;
        }
        else
        {
            Debug.LogWarning("Rigidbody2D component not found on the spawned object.");
        }
    }
}
