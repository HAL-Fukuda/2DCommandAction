using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public partial class EnemyAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    Vector3 pos = new Vector3(10, 2, 0);

    void ReflectionAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �v���C���[�Ɍ������ăI�u�W�F�N�g�𔭎˂��鏈�������s
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        // �I�u�W�F�N�g�𐶐����āA�v���C���[�̈ʒu�Ɍ������Ĕ��˂���
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Vector2 direction = (pos - transform.position);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = direction * projectileSpeed;
    }
}
