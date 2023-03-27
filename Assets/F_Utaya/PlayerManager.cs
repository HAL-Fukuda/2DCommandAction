using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //�C���X�y�N�^�[�Őݒ肷��
    public float        moveSpeed;          //�ړ����x
    public int          AvoidanceForce;     //��𑬓x
    public float        upForce;            //�W�����v��
    public bool         isDoubleJump;

    public Transform    attackPoint;
    public float        attackRadius;
    public LayerMask    enemyLayer;
    public LayerMask    commandLayer;

    public float Chargeingcount = 0.0f;

    public bool isGround;         //�ڒn����

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
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("�E���");
                rb.AddForce(new Vector3(AvoidanceForce, 0, 0));
            }
        }
        //������
        else if (x < 0)
        {
            transform.localScale = new Vector3(2, 2, 1);
            //���
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("�����");
                rb.AddForce(new Vector3(-AvoidanceForce, 0, 0));
            }
        }

        //���ߒ�
        if (Input.GetKey(KeyCode.Return))
        {
            Chargeing();
        }
        //���ߍU��
        if (Input.GetKeyUp(KeyCode.Return))
        {
            if (Chargeingcount >= 0.0f && Chargeingcount < 400.0f)
            {
                Debug.Log("�U���F��i�K");
                Attack();
            }
            else if (Chargeingcount >= 400.0f)
            {
                Debug.Log("�U���F��i�K");
                Attack();
            }
            Chargeingcount = 0.0f;
        }

        //�W�����v
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isDoubleJump = false;
            rb.AddForce(new Vector3(0, upForce, 0));
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && isDoubleJump == false)
            {
                rb.AddForce(new Vector3(0, upForce, 0));
                isDoubleJump = true;
            }
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
    
    //���ߒ�
    void Chargeing()
    {
        Debug.Log("���ߒ�");
        animator.SetTrigger("isChargeing");
        Chargeingcount += 0.1f;
        Debug.Log(Chargeingcount);
    }

    //�U���̏���
    void Attack()
    {
        animator.SetTrigger("isAttack");
        Debug.Log("�U��");
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
