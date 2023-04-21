using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings nailAttackSettings;

    public void NailAttack()
    {
        nailAttackSettings.timer += Time.deltaTime;

        if (nailAttackSettings.timer >= nailAttackSettings.spawnInterval)
        {
            nailAttackSettings.timer = 0f;
            //GameObject nail = Instantiate(nailAttackSettings.prefab, transform.position, Quaternion.identity);

            // �v���C���[�I�u�W�F�N�g���擾����
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                // �v���C���[�I�u�W�F�N�g�̍��W���擾����
                Vector3 spawnPosition = playerObject.transform.position;

                // �v���n�u���X�|�[������
                GameObject nail = Instantiate(nailAttackSettings.prefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
