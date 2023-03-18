using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //�C���X�y�N�^�[�Őݒ肷��
    public float        moveSpeed;      //�ړ����x
    //public float        jumpSpeed;      //�W�����v���x
    //public float        jumpHeight;     //�W�����v�̍�������
    //public float        jumpLimitTime;  //�W�����v��������
    //public float        gravity;        //�d��
    
    //public GroundCheck  ground;         //�ڒn����
    //public GroundCheck  head;            //�����Ԃ�������
    public Transform    attackPoint;
    public float        attackRadius;
    public LayerMask    enemyLayer;

    Rigidbody2D         rb;
    Animator            animator;
    //private float jumpPos = 0.0f;
    //private float jumpTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    //�ړ��̏���
    void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");       //������

        //�E����
        if (x > 0)
        {
            transform.localScale = new Vector3(-2, 2, 1);
        }
        //������
        else if (x < 0)
        {
            transform.localScale = new Vector3(2, 2, 1);
        }

        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }


        animator.SetFloat("Speed", Mathf.Abs(x));
        rb.velocity = new Vector2(x * moveSpeed,rb.velocity.y);
    }

    //�U���̏���
    void Attack()
    {
        animator.SetTrigger("isAttack");
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);
        //foreach(Collider2D hitEnemy in hitEnemys)
        //{
        //    hitEnemy.GetComponent<EnemyManager>().OnDamage();
        //}
    }

    //�����蔻��̂Ƃ���Ԃ��~�ŕ`��
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

}
