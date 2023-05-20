using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shout : MonoBehaviour
{
    private Transform target;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        // �v���C���[���^�[�Q�b�g�ɂ���
        GameObject player = GameObject.Find("Player");
        target = player.transform;

        // �^�[�Q�b�g�̕���������
        ForcusTarget();

        // �J������h�炷
        CameraEffect cameraScript = GameObject.Find("Main Camera").GetComponent<CameraEffect>();
        cameraScript.ShakeCamera(0.2f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer> 2.0f)
        {
            Destroy(this.gameObject);
        }
    }

    // �^�[�Q�b�g�̕���������
    void ForcusTarget()
    {
        // �^�[�Q�b�g�̈ʒu���玩�����g�̃I�u�W�F�N�g�̈ʒu�������āA�����x�N�g�������߂�B
        Vector3 direction = target.position - this.transform.position;

        // �����x�N�g�����g���āA��]�p�x�����߂�B
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ��]�p�x���������g�̃I�u�W�F�N�g�ɓK�p����B
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
