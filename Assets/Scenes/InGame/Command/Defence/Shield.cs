using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private GameObject player;
    private GameObject lifeMgr;
    public float lifeTimer = 3.0f; // ��������

    void Start()
    {
        player = GameObject.Find("Player");
        lifeMgr = GameObject.Find("Life");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowPlayerPosition();

        // �^�C�}�[�����炷
        lifeTimer -= Time.deltaTime;

        // �������Ԃ��O�ɂȂ�����폜
        if(lifeTimer < 0)
        {
            lifeMgr.GetComponent<LifeManager>().InvincibilityOff();    // ���Goff
            Destroy(this.gameObject);
        }
    }

    // �v���C���[�̍��W�ɒǏ]����
    private void FollowPlayerPosition()
    {
        Vector3 pos = player.transform.position;
        pos += new Vector3(0, 1, 0);
        this.transform.position = pos;
    }
}
