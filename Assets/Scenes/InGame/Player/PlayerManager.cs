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
   

    public float moveSpeed;          //移動速度
    public float upForce;            //ジャンプ力
    public float cooldownTime;
    private bool notJump = false;
    public bool isHaveCommand = false;
    private bool isCooldown = false;

    public Transform attackPoint;
    public float attackRadius;
    public LayerMask enemyLayer;
    public LayerMask commandLayer;

    public bool isGround;         //地面についているか
    public bool isMove;           //動いていいか

    Rigidbody2D rb;
    Animator animator;
    private Button button;

    public float length = 0.6f;         //コマンドを判定する頭上のレイの長さ
    private int direction;              //向きを判定する
    private float overhead = 2.0f;      //コマンドを配置する位置
    private float ThrowPower = 4.0f;    //投げる力
    private GameObject commandObject;

    // 以前に触れたオブジェクトのタグを保存するキー
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

    //移動の処理
    void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");       //横方向

        //右向き
        if (x > 0)
        {
            direction = 1;
            transform.localScale = new Vector3(-2, 2, 1);
        }
        //左向き
        else if (x < 0)
        {
            direction = -1;
            transform.localScale = new Vector3(2, 2, 1);
        }

        // コマンドを持っている時は攻撃できない
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

        //ジャンプ
        if ((Input.GetKeyDown(KeyCode.Space) && isGround) || (Input.GetButtonDown("A")) && isGround)//追加
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

    //接地判定
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

    // プレイヤーがオブジェクトに触れたときに呼び出される関数
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 以前に触れたオブジェクトのタグを保存する
        PlayerPrefs.SetString(previousTagKey, other.tag);
    }

    // 特定のオブジェクトに触れたときに呼び出される関数
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 以前に触れたオブジェクトのタグを読み込む
        string previousTag = PlayerPrefs.GetString(previousTagKey);

        // 特定のオブジェクトであれば、地面に接触している場合に限り、他のオブジェクトに触れるまで処理を行わない
        if (collision.gameObject.CompareTag("Swamp") && previousTag == "Swamp" && isGround)
        {
            // 何もしない
            notJump = true;
            return;
        }

        // 以前に触れたオブジェクトのタグを削除する
        PlayerPrefs.DeleteKey(previousTagKey);
        notJump = false;
    }

    //ジャンプのアニメーション
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

    //ダメージを受けたときのアニメーション
    public void DamegeAnimation()
    {
        // SE再生
        AudioSource.PlayClipAtPoint(HitDamageSE, transform.position);
        animator.SetTrigger("isDamege");
    }

    //ゲームオーバーのアニメーション
    public void DieAnimation()
    {
        isMove = false;
        animator.SetTrigger("isDie");
    }

    //攻撃の処理
    void Attack()
    {
        AudioSource.PlayClipAtPoint(AttackSE, transform.position);
        animator.SetTrigger("isAttack");

        //コマンドに
        Collider2D[] hitCommands = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, commandLayer);
        foreach (Collider2D hitCommand in hitCommands)
        {
            CommandMgr.Instance.AttackHit(hitCommand.gameObject);
        }

        // 空中で動きを少し止める
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
        if ((Input.GetKeyDown(KeyCode.U) && !isHaveCommand) || (Input.GetButtonUp("X")) && !isHaveCommand)//追加
        {
            Hold();
        }
        if (isHaveCommand)
        {
            commandObject.transform.position = transform.position + new Vector3(0, overhead, 0);
            if ((Input.GetKeyDown(KeyCode.L)) || (Input.GetButtonDown("X")))//追加
            {
                Throw();
            }
        }
    }


    void Hold()
    {
        // 攻撃ポイントから前方に向けてレイを飛ばし、最初に衝突したオブジェクトを取得する
        RaycastHit2D hit = Physics2D.Raycast(attackPoint.position, attackPoint.up, length, commandLayer);
        if (hit.collider != null)
        {
            isHaveCommand = true;
            // 衝突した"command"オブジェクトを取得
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

            // "command"オブジェクトのRigidbody2Dコンポーネントを取得し、速度と方向を設定して投げる
            Rigidbody2D rigidbody = commandObject.GetComponent<Rigidbody2D>();
            rigidbody.simulated = true;
            Vector3 velocity = (transform.right * direction + transform.up) * ThrowPower;
            rigidbody.velocity = velocity;     //ベクトルを代入
            isHaveCommand = false;
        }
    }

    //当たり判定のとこを赤い円で描く
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    // 空中停止の終了処理
    private void FreezePosition2D()
    {
        //rb.simulated = true;
        rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        rb.velocity = new Vector2(rb.velocity.x, 0); // 落下速度をリセットする
    }
}
