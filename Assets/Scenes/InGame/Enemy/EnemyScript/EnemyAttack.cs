using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour //partial C++�̃N���X
{
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()//������
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // MeteorAttack();
        // ReflectionAttack();
        // SidewaysAttack();
    }

}
