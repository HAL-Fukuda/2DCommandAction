using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerManager : MonoBehaviour
{
    public AudioClip HitDamageSE;
    //[SerializeField] GameObject slash;
    //[SerializeField] GameObject Bigslash;

    //インスペクターで設定する
    public float moveSpeed;          //移動速度
    //public int AvoidanceForce;     //回避速度
    public float upForce;            //ジャンプ力
    //private bool isDoubleJump;
    private bool notJump = false;
    public bool isHaveCommand = false;

    public Transform attackPoint;
    public float attackRadius;
    public LayerMask enemyLayer;
    public LayerMask commandLayer;

    //private float Chargeingcount = 0.0f;

    public bool isGround;         //接地判定
    public bool isMove;

    Rigidbody2D rb;
    Animator animator;

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
        //CantJump();

        //if (Input.GetKeyDown(KeyCode.N))
        //{
        //    DamegeAnimation();
        //}
        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    DieAnimation();
        //}
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
            //if (Input.GetKeyDown(KeyCode.LeftShift))
            //{
            //    //Debug.Log("右回避");
            //    rb.AddForce(new Vector3(AvoidanceForce, 0, 0));
            //}
        }
        //左向き
        else if (x < 0)
        {
            direction = -1;
            transform.localScale = new Vector3(2, 2, 1);
            ////回避
            //if (Input.GetKeyDown(KeyCode.LeftShift))
            //{
            //    //Debug.Log("左回避");
            //    rb.AddForce(new Vector3(-AvoidanceForce, 0, 0));
            //}
        }

        // コマンドを持っている時は攻撃できない
        if (isHaveCommand == false)
        {
            if ((Input.GetKeyUp(KeyCode.Return)) || (Input.GetButtonUp("B")))
            {
                Attack();
            }
            ////ため中
            //if ((Input.GetKey(KeyCode.Return) && isGround) || (Input.GetButtonDown("B")) && isGround)//追加
            //{
            //    Chargeing();
            //}
            ////ため攻撃
            //if ((Input.GetKeyUp(KeyCode.Return)) || (Input.GetButtonUp("B")))//追加
            //{

            //    if (Chargeingcount >= 0.0f && Chargeingcount < 400.0f)
            //    {
            //        //Debug.Log("攻撃：一段階");
            //        Attack();
            //    }
            //    else if (Chargeingcount >= 400.0f)
            //    {
            //        //Debug.Log("攻撃：二段階");
            //        Attack();
            //    }

            //    Chargeingcount = 0.0f;
            //}
        }

        //ジャンプ
        if ((Input.GetKeyDown(KeyCode.Space) && isGround) || (Input.GetButtonDown("A")) && isGround)//追加
        {
            //isDoubleJump = false;
            rb.AddForce(new Vector3(0, upForce, 0));
        }
        //else if ((Input.GetKeyDown(KeyCode.Space) && isDoubleJump == false) || (Input.GetButtonDown("A")) && isDoubleJump == false)//追加
        //{
        //    if (rb.velocity.y < 0) // 下降中に二段目のジャンプを行う場合
        //    {
        //        rb.velocity = new Vector2(rb.velocity.x, 0); // 落下速度をリセットする
        //        rb.AddForce(new Vector3(0, upForce * 1.5f, 0)); // 上方向に大きな力を加える
        //    }
        //    else // 上昇中に二段目のジャンプを行う場合
        //    {
        //        rb.AddForce(new Vector3(0, upForce, 0));
        //    }
        //    isDoubleJump = true;
        //}

        animator.SetFloat("Speed", Mathf.Abs(x));
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);

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

    //void CantJump()
    //{
    //    if (notJump)
    //    {
    //        //isDoubleJump = true;
    //    }
    //}

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
        //Debug.Log("ダメージを受けています");
    }

    //ゲームオーバーのアニメーション
    public void DieAnimation()
    {
        isMove = false;
        animator.SetTrigger("isDie");
        //Debug.Log("死にました");
    }

    ////溜め中
    //void Chargeing()
    //{
    //    animator.SetBool("ChargingNow", true);
    //    Chargeingcount += 0.1f;
    //    //Debug.Log("溜め中");
    //    //Debug.Log(Chargeingcount);
    //}

    //攻撃の処理
    void Attack()
    {
        //animator.SetBool("ChargingNow", false);
        animator.SetTrigger("isAttack");
        //Debug.Log("攻撃");
        //エネミーに
        //Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);
        //foreach (Collider2D hitEnemy in hitEnemys)
        //{
        //    hitEnemy.GetComponent<Enemy>().GetDamage();
        //}
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
            // "command"オブジェクトのRigidbody2Dコンポーネントを取得し、速度と方向を設定して投げる
            Rigidbody2D rigidbody = commandObject.GetComponent<Rigidbody2D>();
            rigidbody.simulated = true;
            Vector3 velocity = (transform.right * direction + transform.up) * ThrowPower;
            rigidbody.velocity = velocity;     //ベクトルを代入
            isHaveCommand = false;
        }
    }

    //void specialattack()
    //{
    //    this.transform.DOMove(new Vector3(-3.689993f, -2.374583f, 0f), 1.5f);
    //    transform.localScale = new Vector3(-2, 2, 1);
    //    StartCoroutine("SPChargingNow");
    //    Invoke(nameof(Slash), 2.0f);
    //    Invoke(nameof(Slash), 3.0f);
    //    Invoke(nameof(Slash), 4.0f);
    //    Invoke(nameof(BigSlash), 5.5f);
    //}

    //void Slash()
    //{
    //    animator.SetTrigger("isSPAttack");
    //    //プレイヤーの座標を取得
    //    Vector2 position = transform.position;
    //    //プレイヤーとかぶらなくする
    //    position.x += 1;
    //    position.y += 1;
    //    Instantiate(slash, position, transform.rotation);
    //}

    //void BigSlash()
    //{
    //    animator.SetTrigger("isSPAttack");
    //    Instantiate(Bigslash, transform.position, transform.rotation);
    //}

    //IEnumerator SPChargingNow()
    //{
    //    animator.SetBool("SPChargingNow", true);
    //    isMove = false;
    //    yield return new WaitForSeconds(5.5f);
    //    animator.SetBool("SPChargingNow", false);
    //    isMove = true;
    //}

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
