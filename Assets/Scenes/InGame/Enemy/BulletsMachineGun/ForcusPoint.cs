using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcusPoint : MonoBehaviour
{
    public ParticleSystem bulletsObj;  //��������Prefab

    private GameObject playerObj;  //Player�̈ʒu
    private Transform target;

    private GameObject enemyObj;  //Enemy�̈ʒu
    private Vector3 enemyPos;

    private ParticleSystem _bulletsInstance;  //�����p

    private float forcusTimer;   //�o�ߎ���
    private float speed = 25f;  //�Ǐ]���x

    private bool oneceShot = false;  //��񂾂��ĂԂ悤��

    void Start()
    {
        //Enemy�̈ʒu���擾
        enemyObj = GameObject.FindWithTag("Enemy");
        enemyPos = enemyObj.transform.position;
        //�^�C�}�[�̏�����
        forcusTimer = 0f;
        //��񂾂��ĂԂ悤��
        oneceShot = true;
    }
    
    void FixedUpdate()
    {
        forcusTimer += Time.deltaTime;

        //Player�̈ʒu���擾
        playerObj = GameObject.FindWithTag("Player");
        target = playerObj.transform;

        //��������1�b��Player��Ǐ]
        if (forcusTimer <= 1f)
        {
            ForcusMove();
        }

        //��������1�b��ɐ���
        if (forcusTimer >= 1f)
        {
            if (oneceShot)
            {
                BulletsSpawn();
                oneceShot = false;
            }
        }

        //��������3.5�b��ɔj��
        if (forcusTimer >= 3.5f)
        {
            Destroy(this.gameObject);
        }
    }

    //Player��Ǐ]
    void ForcusMove()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(target.transform.position.x, target.transform.position.y + 1), speed * Time.deltaTime);
    }

    //����
    void BulletsSpawn()
    {
        _bulletsInstance = Instantiate(bulletsObj, enemyPos, Quaternion.identity);
    }
}
