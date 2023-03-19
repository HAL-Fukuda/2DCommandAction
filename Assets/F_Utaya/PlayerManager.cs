using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //�C���X�y�N�^�[�Őݒ肷��
    public float        moveSpeed;      //�ړ����x
    public float        upForce;        //�W�����v��
  
    public bool isGround;         //�ڒn����
   
    public Transform    attackPoint;
    public float        attackRadius;
    public LayerMask    enemyLayer;
    public LayerMask    commandLayer;

    Rigidbody2D         rb;
    Animator            animator;

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
        //�U��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        //�W�����v
        if(Input.GetKeyDown(KeyCode.W) && isGround)
        {
            animator.SetTrigger("isJump");
            rb.AddForce(new Vector3(0, upForce, 0));
        }


        animator.SetFloat("Speed", Mathf.Abs(x));
        rb.velocity = new Vector2(x * moveSpeed,rb.velocity.y);
        
    }

    //�ڒn����
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Platform")
        {
            isGround = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Platform")
        {
            isGround = false;
        }
    }

    //�U���̏���
    void Attack()
    {
        animator.SetTrigger("isAttack");
        //�G�l�~�[��
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);
        foreach (Collider2D hitEnemy in hitEnemys)
        {
            hitEnemy.GetComponent<Enemy>().GetDamage();
        }
        //�R�}���h��
        Collider2D[] hitCommands = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, commandLayer);
        foreach (Collider2D hitCommand in hitCommands)
        {
            CommandMgr.Instance.AttackHit(hitCommand.gameObject);
        }
    }

    //�����蔻��̂Ƃ���Ԃ��~�ŕ`��
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

}
