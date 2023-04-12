using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //�C���X�y�N�^�[�Őݒ肷��
    public float moveSpeed;          //�ړ����x
    public int AvoidanceForce;     //��𑬓x
    public float upForce;            //�W�����v��
    private bool isDoubleJump;
    private bool isHaveCommand = false;

    public Transform attackPoint;
    public float attackRadius;
    public LayerMask enemyLayer;
    public LayerMask commandLayer;

    private float Chargeingcount = 0.0f;

    public bool isGround;         //�ڒn����

    Rigidbody2D rb;
    Animator animator;

    public float length = 0.6f;         //�R�}���h�𔻒肷�铪��̃��C�̒���
    private int direction;              //�����𔻒肷��
    private float overhead = 2.0f;      //�R�}���h��z�u����ʒu
    private float ThrowPower = 4.0f;    //�������
    private GameObject commandObject;

    // Start is called before the first frame update
    void Start()
    {
        direction = 0;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        JumpAnimation();

        if (Input.GetKeyDown(KeyCode.N))
        {
            DamegeAnimation();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            DieAnimation();
        }

        Movement();
        HoldThrowUpdate();
    }

    //�ړ��̏���
    void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");       //������

        //�E����
        if (x > 0)
        {
            direction = 1;
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
            direction = -1;
            transform.localScale = new Vector3(2, 2, 1);
            //���
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("�����");
                rb.AddForce(new Vector3(-AvoidanceForce, 0, 0));
            }
        }

        //���ߒ�
        if ((Input.GetKey(KeyCode.Return) && isGround) || (Input.GetButtonDown("B")) && isGround)//�ǉ�
        {
            Chargeing();
        }
        //���ߍU��
        if ((Input.GetKeyUp(KeyCode.Return)) || (Input.GetButtonUp("B")))//�ǉ�
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
        if ((Input.GetKeyDown(KeyCode.Space) && isGround) || (Input.GetButtonDown("A")) && isGround)//�ǉ�
        {
            isDoubleJump = false;
            rb.AddForce(new Vector3(0, upForce, 0));
        }
        else if ((Input.GetKeyDown(KeyCode.Space) && isDoubleJump == false) || (Input.GetButtonDown("A")) && isDoubleJump == false)//�ǉ�
        {
            if (rb.velocity.y < 0) // ���~���ɓ�i�ڂ̃W�����v���s���ꍇ
            {
                rb.velocity = new Vector2(rb.velocity.x, 0); // �������x�����Z�b�g����
                rb.AddForce(new Vector3(0, upForce * 1.5f, 0)); // ������ɑ傫�ȗ͂�������
            }
            else // �㏸���ɓ�i�ڂ̃W�����v���s���ꍇ
            {
                rb.AddForce(new Vector3(0, upForce, 0));
            }
            isDoubleJump = true;
        }

        animator.SetFloat("Speed", Mathf.Abs(x));
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);

    }

    //�ڒn����
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Platform" || other.gameObject.tag == "Command")
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

    //�W�����v�̃A�j���[�V����
    void JumpAnimation()
    {
        if (isGround == false)
        {
            animator.SetBool("JumpNow", true);
        }
        else if (isGround == true)
        {
            animator.SetBool("JumpNow", false);
        }
    }

    //�_���[�W���󂯂��Ƃ��̃A�j���[�V����
    void DamegeAnimation()
    {
        animator.SetTrigger("isDamege");
    }

    //�Q�[���I�[�o�[�̃A�j���[�V����
    void DieAnimation()
    {
        animator.SetTrigger("isDie");
    }

    //���ߒ�
    void Chargeing()
    {
        animator.SetBool("ChargingNow", true);
        Chargeingcount += 0.1f;
        //Debug.Log("���ߒ�");
        //Debug.Log(Chargeingcount);
    }

    //�U���̏���
    void Attack()
    {
        animator.SetBool("ChargingNow", false);
        animator.SetTrigger("isAttack");
        //Debug.Log("�U��");
        //�G�l�~�[��
        //Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);
        //foreach (Collider2D hitEnemy in hitEnemys)
        //{
        //    hitEnemy.GetComponent<Enemy>().GetDamage();
        //}
        //�R�}���h��
        Collider2D[] hitCommands = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, commandLayer);
        foreach (Collider2D hitCommand in hitCommands)
        {
            CommandMgr.Instance.AttackHit(hitCommand.gameObject);
        }

        // �󒆂œ����������~�߂�
        if (isGround == false)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY
                | RigidbodyConstraints2D.FreezePositionX
                | RigidbodyConstraints2D.FreezeRotation;
            Invoke("FreezePosition2D", 0.3f);
        }
    }

    void HoldThrowUpdate()
    {
        if ((Input.GetKeyDown(KeyCode.U) && !isHaveCommand) || (Input.GetButtonUp("X")) && !isHaveCommand)//�ǉ�
        {
            Hold();
        }
        if (isHaveCommand)
        {
            commandObject.transform.position = transform.position + new Vector3(0, overhead, 0);
            if ((Input.GetKeyDown(KeyCode.L)) || (Input.GetButtonDown("X")))//�ǉ�
            {
                Throw();
            }
        }
    }


    void Hold()
    {
        // �U���|�C���g����O���Ɍ����ă��C���΂��A�ŏ��ɏՓ˂����I�u�W�F�N�g���擾����
        RaycastHit2D hit = Physics2D.Raycast(attackPoint.position, attackPoint.up, length, commandLayer);
        if (hit.collider != null)
        {
            isHaveCommand = true;
            // �Փ˂���"command"�I�u�W�F�N�g���擾
            commandObject = hit.collider.gameObject;
            if (isHaveCommand)
            {
                Rigidbody2D rigidbody = commandObject.GetComponent<Rigidbody2D>();
                rigidbody.simulated = false;
            }
        }
        else
        {
            isHaveCommand = false;
        }
    }

    void Throw()
    {
        if (commandObject != null)
        {
            // "command"�I�u�W�F�N�g��Rigidbody2D�R���|�[�l���g���擾���A���x�ƕ�����ݒ肵�ē�����
            Rigidbody2D rigidbody = commandObject.GetComponent<Rigidbody2D>();
            rigidbody.simulated = true;
            Vector3 velocity = (transform.right * direction + transform.up) * ThrowPower;
            rigidbody.velocity = velocity;     //�x�N�g������
            isHaveCommand = false;
        }
    }

    //�����蔻��̂Ƃ���Ԃ��~�ŕ`��
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    // �󒆒�~�̏I������
    private void FreezePosition2D()
    {
        //rb.simulated = true;
        rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        rb.velocity = new Vector2(rb.velocity.x, 0); // �������x�����Z�b�g����
    }
}
