using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    [System.Serializable]
    public struct AttackSettings
    {
        public GameObject prefab;
        public float spawnInterval;
        public float life;
        [SerializeField][Header("いじらないで")] public float timer;

        public AttackSettings(GameObject prefab, float spawnInterval, float life)
        {
            this.prefab = prefab;
            this.spawnInterval = spawnInterval;
            this.life = life;
            this.timer = 0f;
        }
    }

    public AttackSettings sidewaysAttackSettings;

    public void SidewaysAttack()
    {
        sidewaysAttackSettings.timer += Time.deltaTime;

        if (sidewaysAttackSettings.timer >= sidewaysAttackSettings.spawnInterval)
        {
            sidewaysAttackSettings.timer = 0f;

            // 画面左端にオブジェクトを生成する
            Vector3 spawnPos = new Vector3(-10f, Random.Range(-1f, 0f), 0f);
            GameObject obj = Instantiate(sidewaysAttackSettings.prefab, spawnPos, Quaternion.identity);

            obj.transform.DOMoveX(
                30f, //移動量
                sidewaysAttackSettings.life // 演出時間
            ).OnComplete(() =>
            {
                Destroy(obj);
            });
        }
    }
}