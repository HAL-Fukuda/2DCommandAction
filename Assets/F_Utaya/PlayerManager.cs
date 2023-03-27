using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //インスペクターで設定する
    public float        moveSpeed;          //移動速度
    public int          AvoidanceForce;     //回避速度
    public float        upForce;            //ジャンプ力
    public bool         isDoubleJump;

    public Transform    attackPoint;
    public float        attackRadius;
    public LayerMask    enemyLayer;
    public LayerMask    commandLayer;

    public float Chargeingcount = 0.0f;

    public bool isGround;         //接地判定

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

    //移動の処理
    void Movement()
    {
     
        float x = Input.GetAxisRaw("Horizontal");       //横方向
 
        
        //右向き
        if (x > 0)
        {
            transform.localScale = new Vector3(-2, 2, 1);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("右回避");
                rb.AddForce(new Vector3(AvoidanceForce, 0, 0));
            }
        }
        //左向き
        else if (x < 0)
        {
            transform.localScale = new Vector3(2, 2, 1);
            //回避
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("左回避");
                rb.AddForce(new Vector3(-AvoidanceForce, 0, 0));
            }
        }

        //ため中
        if (Input.GetKey(KeyCode.Return))
        {
            Chargeing();
        }
        //ため攻撃
        if (Input.GetKeyUp(KeyCode.Return))
        {
            if (Chargeingcount >= 0.0f && Chargeingcount < 400.0f)
            {
                Debug.Log("攻撃：一段階");
                Attack();
            }
            else if (Chargeingcount >= 400.0f)
            {
                Debug.Log("攻撃：二段階");
                Attack();
            }
            Chargeingcount = 0.0f;
        }

        //ジャンプ
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

    //接地判定
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
    
    //溜め中
    void Chargeing()
    {
        Debug.Log("溜め中");
        animator.SetTrigger("isChargeing");
        Chargeingcount += 0.1f;
        Debug.Log(Chargeingcount);
    }

    //攻撃の処理
    void Attack()
    {
        animator.SetTrigger("isAttack");
        Debug.Log("攻撃");
        //エネミーに
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);
        foreach (Collider2D hitEnemy in hitEnemys)
        {
            hitEnemy.GetComponent<Enemy>().GetDamage();
        }
        //コマンドに
        Collider2D[] hitCommands = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, commandLayer);
        foreach (Collider2D hitCommand in hitCommands)
        {
            CommandMgr.Instance.AttackHit(hitCommand.gameObject);
        }
    }

    //当たり判定のとこを赤い円で描く
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

}
