using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private GameObject player;
    private GameObject lifeMgr;
    public float lifeTimer = 3.0f; // ��������

    bool isEnemy = false;

    void Start()
    {
        player = GameObject.Find("Player");
        lifeMgr = GameObject.Find("Life");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowPlayerPosition();

        // �G�̃^�[�����I�������V�[���h�𖳌��ɂ���
        if (GameMgr.Instance.battleState == GameMgr.eBattleState.ENEMY)
        {
            isEnemy = true;
        }
        if (isEnemy && GameMgr.Instance.battleState != GameMgr.eBattleState.ENEMY)
        {
            DestroyShield();
        }
    }

    // �v���C���[�̍��W�ɒǏ]����
    private void FollowPlayerPosition()
    {
        Vector3 pos = player.transform.position;
        pos += new Vector3(0, 1, 0);
        this.transform.position = pos;
    }

    public void DestroyShield() // �V�[���h���폜
    {
        lifeMgr.GetComponent<LifeManager>().InvincibilityOff();    // ���Goff
        Destroy(this.gameObject);
    }
}
