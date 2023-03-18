using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //インスペクターで設定する
    public float        moveSpeed;      //移動速度
    public float        jumpSpeed;      //ジャンプ速度
    //public float        jumpHeight;     //ジャンプの高さ制限
    //public float        jumpLimitTime;  //ジャンプ制限時間
    //public float        gravity;        //重力
    
    public GroundCheck  ground;         //接地判定
    //public GroundCheck  head;            //頭をぶつけた判定
    public Transform    attackPoint;
    public float        attackRadius;
    public LayerMask    enemyLayer;

    Rigidbody2D         rb;
    Animator            animator;

    //プライベート変数
    private bool isGround = false;
    //private float jumpPos = 0.0f;
    //private float jumpTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //接地判定を得る
        isGround = ground.IsGround();
        Movement();
    }

    //移動の処理
    void Movement()
    {
        //float ySpeed = -gravity;
        //float verticalKey = Input.GetAxis("Vertical");
        float x = Input.GetAxisRaw("Horizontal");       //横方向
        float y = Input.GetAxisRaw("Vertical");            //縦方向
        
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
        //ジャンプ
        if (isGround)
        {
            Debug.Log(isGround);

            if (y > 0 )
            {
                rb.velocity = new Vector2(rb.velocity.x, y * jumpSpeed);
                Debug.Log("Wが押された");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spaceが押された");
            Attack();
        }

        animator.SetFloat("Speed", Mathf.Abs(x));
        rb.velocity = new Vector2(x * moveSpeed,rb.velocity.y);
        
    }

    //攻撃の処理
    void Attack()
    {
        animator.SetTrigger("isAttack");
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);
        //foreach(Collider2D hitEnemy in hitEnemys)
        //{
        //    hitEnemy.GetComponent<EnemyManager>().OnDamage();
        //}
    }

    //当たり判定のとこを赤い円で描く
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

}
