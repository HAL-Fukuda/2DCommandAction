using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //インスペクターで設定する
    public float        moveSpeed;      //移動速度
    public float        upForce;        //ジャンプ力
  
    public bool isGround;         //接地判定
   
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

    //移動の処理
    void Movement()
    {
     
        float x = Input.GetAxisRaw("Horizontal");       //横方向
 
        
        //右向き
        if (x > 0)
        {
            transform.localScale = new Vector3(-2, 2, 1);
        }
        //左向き
        else if (x < 0)
        {
            transform.localScale = new Vector3(2, 2, 1);
        }
        //攻撃
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        //ジャンプ
        if(Input.GetKeyDown(KeyCode.W) && isGround)
        {
            animator.SetTrigger("isJump");
            rb.AddForce(new Vector3(0, upForce, 0));
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

    //攻撃の処理
    void Attack()
    {
        animator.SetTrigger("isAttack");
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
