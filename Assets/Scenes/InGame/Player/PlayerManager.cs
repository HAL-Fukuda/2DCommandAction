using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    //SE
    public AudioClip JumpSE;
    public AudioClip AttackSE;
    public AudioClip ThrowSE;
    public AudioClip HitDamageSE;
   

    public float moveSpeed;          //�ړ����x
    public float upForce;            //�W�����v��
    public float cooldownTime;
    private bool notJump = false;
    public bool isHaveCommand = false;
    private bool isCooldown = false;

    public Transform attackPoint;
    public float attackRadius;
    public LayerMask enemyLayer;
    public LayerMask commandLayer;

    public bool isGround;         //�n�ʂɂ��Ă��邩
    public bool isMove;           //�����Ă�����

    Rigidbody2D rb;
    Animator animator;
    private Button button;

    public float length = 0.6f;         //�R�}���h�𔻒肷�铪��̃��C�̒���
    private int direction;              //�����𔻒肷��
    private float overhead = 2.0f;      //�R�}���h��z�u����ʒu
    private float ThrowPower = 4.0f;    //�������
    private GameObject commandObject;

    // �ȑO�ɐG�ꂽ�I�u�W�F�N�g�̃^�O��ۑ�����L�[
    private const string previousTagKey = "PreviousTag";

    // Start is called before the first frame update
    void Start()
    {
        direction = 0;
        isMove = true;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        JumpAnimation();

        if (isMove)
        {
            Movement();
            HoldThrowUpdate();
        }
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
        }
        //������
        else if (x < 0)
        {
            direction = -1;
            transform.localScale = new Vector3(2, 2, 1);
        }

        // �R�}���h�������Ă��鎞�͍U���ł��Ȃ�
        if (isHaveCommand == false)
        {
            if (!isCooldown)
            {
                if ((Input.GetKeyUp(KeyCode.Return)) || (Input.GetButtonUp("B")))
                {
                    Attack();

                    isCooldown = true;
                    Invoke("ResetCooldown", cooldownTime);
                }
            }
        }

        //�W�����v
        if ((Input.GetKeyDown(KeyCode.Space) && isGround) || (Input.GetButtonDown("A")) && isGround)//�ǉ�
        {
            AudioSource.PlayClipAtPoint(JumpSE, transform.position);
            rb.AddForce(new Vector3(0, upForce, 0));
        }

        animator.SetFloat("Speed", Mathf.Abs(x));
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);
    }

    private void ResetCooldown()
    {
        isCooldown = false;
    }

    //�ڒn����
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Platform" || other.gameObject.tag == "Command" || other.gameObject.tag == "Swamp")
        {
            isGround = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Platform" || other.gameObject.tag == "Command" || other.gameObject.tag == "Swamp")
        {
            isGround = false;
        }
    }

    // �v���C���[���I�u�W�F�N�g�ɐG�ꂽ�Ƃ��ɌĂяo�����֐�
    private void OnTriggerEnter2D(Collider2D other)
    {
        // �ȑO�ɐG�ꂽ�I�u�W�F�N�g�̃^�O��ۑ�����
        PlayerPrefs.SetString(previousTagKey, other.tag);
    }

    // ����̃I�u�W�F�N�g�ɐG�ꂽ�Ƃ��ɌĂяo�����֐�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �ȑO�ɐG�ꂽ�I�u�W�F�N�g�̃^�O��ǂݍ���
        string previousTag = PlayerPrefs.GetString(previousTagKey);

        // ����̃I�u�W�F�N�g�ł���΁A�n�ʂɐڐG���Ă���ꍇ�Ɍ���A���̃I�u�W�F�N�g�ɐG���܂ŏ������s��Ȃ�
        if (collision.gameObject.CompareTag("Swamp") && previousTag == "Swamp" && isGround)
        {
            // �������Ȃ�
            notJump = true;
            return;
        }

        // �ȑO�ɐG�ꂽ�I�u�W�F�N�g�̃^�O���폜����
        PlayerPrefs.DeleteKey(previousTagKey);
        notJump = false;
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
    public void DamegeAnimation()
    {
        // SE�Đ�
        AudioSource.PlayClipAtPoint(HitDamageSE, transform.position);
        animator.SetTrigger("isDamege");
    }

    //�Q�[���I�[�o�[�̃A�j���[�V����
    public void DieAnimation()
    {
        isMove = false;
        animator.SetTrigger("isDie");
    }

    //�U���̏���
    void Attack()
    {
        AudioSource.PlayClipAtPoint(AttackSE, transform.position);
        animator.SetTrigger("isAttack");

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

    public void Throw()
    {
        if (commandObject != null)
        {
            AudioSource.PlayClipAtPoint(ThrowSE, transform.position);

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
