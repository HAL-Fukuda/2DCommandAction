using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour
{
    public GameObject homingPrefab; // �G�̃v���n�u
    public Transform player; // �v���C���[��Transform

    // �w�肵���������G�𐶐�����֐�
    public void SpawnEnemies(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector2 spawnPosition = Random.insideUnitCircle * 10f; // �G�̏o���ʒu�������_���Ɍ���
            GameObject enemy = Instantiate(homingPrefab, transform.position, Quaternion.identity); // �G�𐶐�
            //enemy.GetComponent<EnemyAttack>().SetTarget(player); // �������ꂽ�G���v���C���[��ǂ�������悤�ɐݒ�
        }
    }
    //-----------------------------------
    //public float speed = 5f; // �G�̈ړ����x
    //private Transform target; // �ǂ�������Ώ�

    //public void SetTarget(Transform target)
    //{
    //    this.target = target;
    //}

    //void Update()
    //{
    //    if (target != null)
    //    {
    //        Vector2 direction = (target.position - transform.position).normalized; // �ΏۂɌ������������v�Z
    //        transform.position += (Vector3)direction * speed * Time.deltaTime; // �����ɉ����Ĉړ�
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    // �Փ˂����I�u�W�F�N�g��Player�^�O�������Ă���ꍇ�A���g��j�󂷂�
    //    if (other.CompareTag("Player"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
