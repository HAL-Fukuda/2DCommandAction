using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    [System.Serializable]
    public struct FeatherAttackSettings
    {
        public GameObject feather1;
        public GameObject feather2;
        public GameObject feather3;
        public float spawnInterval;
        public int maxSpawnValue;
        [SerializeField][Header("������Ȃ���")]
        public int spawnValue;
        public float timer;

        public FeatherAttackSettings(GameObject prefab1, GameObject prefab2, GameObject prefab3, float spawnInterval, int maxSpawnValue)
        {
            this.feather1 = prefab1;
            this.feather2 = prefab2;
            this.feather3 = prefab3;
            this.spawnInterval = spawnInterval;
            this.maxSpawnValue = maxSpawnValue;
            this.spawnValue = 0;
            this.timer = 0.0f;
        }
    }
    public FeatherAttackSettings featherAttackSettings;

    public void FeatherAttackInitialize()
    {
        featherAttackSettings.spawnValue = 0;
    }

    // �H��΂��U��
    public void FeatherAttack()
    {
        // �^�C�}�[�X�V
        featherAttackSettings.timer += Time.deltaTime;

        // ��莞�Ԃ��Ƃɐ���
        if (featherAttackSettings.timer >= featherAttackSettings.spawnInterval &&
            featherAttackSettings.spawnValue<featherAttackSettings.maxSpawnValue) // �ő吶�����ɒB���Ă��Ȃ���
        {
            featherAttackSettings.timer = 0f;
            featherAttackSettings.spawnValue++;

            // �G�l�~�[�̓���ӂ�ɐ���
            Vector3 spawnPos = new Vector3(Random.Range(-10f, 10f), 7f, 0f);

            switch(Random.Range(0, 3)){
                case 0:
                    Instantiate(featherAttackSettings.feather1, spawnPos, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(featherAttackSettings.feather2, spawnPos, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(featherAttackSettings.feather3, spawnPos, Quaternion.identity);
                    break;
            }
        }
    }
}
