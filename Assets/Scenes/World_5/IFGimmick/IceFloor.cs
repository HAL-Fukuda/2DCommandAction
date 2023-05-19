using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFloor : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private float timer = 0f;
    private bool isColliding = false;
    GameObject player;

    // public AudioClip se;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        boxCollider = this.GetComponent<BoxCollider2D>();
    }

    public void ToggleCollider(bool enabled)
    {
        boxCollider.enabled = enabled;
    }

    private void Update()
    {
        if (isColliding)
        {
            timer += Time.deltaTime;
            if (timer >= 3f)
            {
                Debug.Log("ice");
                timer = 0f;
                StartCoroutine(DisablePlayerMovementForSeconds(2f));
                //AudioSource.PlayClipAtPoint(se, transform.position);
            }
        }
        else
        {
            timer = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isColliding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isColliding = false;
        }
    }

    private IEnumerator DisablePlayerMovementForSeconds(float seconds)
    {
        // PlayerManager�X�N���v�g���A�^�b�`����Ă���Q�[���I�u�W�F�N�g���擾
        //GameObject player = GameObject.FindGameObjectWithTag("Player");

        // PlayerManager�R���|�[�l���g���擾
        PlayerManager playerManager = player.GetComponent<PlayerManager>();

        // PlayerManager��isMove�𖳌��ɂ���
        playerManager.isMove = false;

        yield return new WaitForSeconds(seconds);

        // �w�莞�ԑҋ@��APlayerManager��isMove��L���ɂ���
        playerManager.isMove = true;
    }
}