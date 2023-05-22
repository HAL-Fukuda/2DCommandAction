using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusPoint : MonoBehaviour
{
    public ParticleSystem bulletsMachineGunObj;

    private GameObject playerObj;
    private Transform target;

    private GameObject enemyObj;
    private Vector3 enemyPos;

    private ParticleSystem _bulletsInstance;

    private float forcusTimer;
    private float speed = 25f;

    private bool onceShot = false;

    void Start()
    {
        enemyObj = GameObject.FindWithTag("Enemy");
        enemyPos = enemyObj.transform.position;

        forcusTimer = 0f;

        onceShot = true;
    }
    
    void Update()
    {
        forcusTimer += Time.deltaTime;

        playerObj = GameObject.FindWithTag("Player");
        target = playerObj.transform;

        if (forcusTimer <= 1f)
        {
            ForcusMove();
        }

        if (forcusTimer >= 2f)
        {
            if (onceShot)
            {
                BulletsSpawn();
                onceShot = false;
            }
        }

        if (forcusTimer >= 3.5f)
        {
            Destroy(this.gameObject);
        }
    }

    void ForcusMove()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(target.transform.position.x, target.transform.position.y + 1), speed * Time.deltaTime);
    }

    void BulletsSpawn()
    {
        _bulletsInstance = Instantiate(bulletsMachineGunObj, enemyPos, Quaternion.identity);
    }
}
