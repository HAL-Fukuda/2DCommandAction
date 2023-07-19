using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour
{

    [System.Serializable]
    public struct SideMissileAttackSettings
    {
        public enum eDirection
        {
            left,
            right
        }

        public GameObject prefab;
        public float spawnInterval;
        public int maxSpawnValue;
        public eDirection direction;

        [SerializeField]
        [Header("������Ȃ���")]
        public int spawnValue;
        public float timer;
        public Vector3 spawnPosition;

        public SideMissileAttackSettings(GameObject prefab, float spawnInterval, int maxSpawnValue, eDirection direction)
        {
            this.prefab = prefab;
            this.spawnInterval = spawnInterval;
            this.maxSpawnValue = maxSpawnValue;
            this.direction = direction;
            this.spawnValue = 0;
            this.timer = 0.0f;
            this.spawnPosition = new Vector3(0, 0, 0);
        }
    }

    public SideMissileAttackSettings sideMissileAttackSettings;

    public void SideMissileInitialize()
    {
        // �����������Z�b�g
        sideMissileAttackSettings.spawnValue = 0;
        // �����ʒu�����Z�b�g
        sideMissileAttackSettings.spawnPosition = new Vector3(0, 0, 0);

        // ���˕����𗐐��Őݒ�
        int randomNumber = new System.Random().Next(2);
        if (randomNumber == 0)
        {
            sideMissileAttackSettings.prefab.GetComponent<SideMissile>().direction = SideMissile.eDirection.right;
            sideMissileAttackSettings.direction = SideMissileAttackSettings.eDirection.right;
        }
        else if (randomNumber == 1)
        {
            sideMissileAttackSettings.prefab.GetComponent<SideMissile>().direction = SideMissile.eDirection.left;
            sideMissileAttackSettings.direction = SideMissileAttackSettings.eDirection.left;
        }
        else
        {
            // �����������ł��Ȃ������ꍇ�̓G���[
            Debug.Log("�������G���[�FSideMissileAttak");
            // �E������ݒ肵�Ă���
            sideMissileAttackSettings.prefab.GetComponent<SideMissile>().direction = SideMissile.eDirection.right;
            sideMissileAttackSettings.direction = SideMissileAttackSettings.eDirection.right;
        }
    }

    // �����E����~�T�C������
    public void SideMissileAttack()
    {
        // �^�C�}�[�X�V
        sideMissileAttackSettings.timer += Time.deltaTime;

        // ��莞�Ԃ��Ƃɐ���
        if (sideMissileAttackSettings.timer >= sideMissileAttackSettings.spawnInterval &&
            sideMissileAttackSettings.spawnValue < sideMissileAttackSettings.maxSpawnValue) // �ő吶�����ɒB���Ă��Ȃ���
        {
            sideMissileAttackSettings.timer = 0f;
            sideMissileAttackSettings.spawnValue++;

            // �����ʒu���擾 
            if (sideMissileAttackSettings.spawnPosition == new Vector3(0, 0, 0)) // �����ʒu���Z�b�g����Ă��Ȃ���Ώ����ʒu���Z�b�g����
            {

                // �����͈͂�X11 Y7~-1 Z0
                if (sideMissileAttackSettings.direction == SideMissileAttackSettings.eDirection.right)
                {
                    sideMissileAttackSettings.spawnPosition = new Vector3(-11, 7, 0);
                }
                if (sideMissileAttackSettings.direction == SideMissileAttackSettings.eDirection.left)
                {
                    sideMissileAttackSettings.spawnPosition = new Vector3(11, 7, 0);
                }
            }

            // ����
            Instantiate(sideMissileAttackSettings.prefab, sideMissileAttackSettings.spawnPosition, Quaternion.identity);

            // ���̐����ʒu���v�Z
            sideMissileAttackSettings.spawnPosition.y -= 1f;
        }
    }
}
