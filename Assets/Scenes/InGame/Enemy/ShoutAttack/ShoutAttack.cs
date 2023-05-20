using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour
{
    [System.Serializable]
    public struct ShoutAttackSettings
    {
        public GameObject prefab;
        public int maxSpawnValue;
        [SerializeField]
        [Header("Ç¢Ç∂ÇÁÇ»Ç¢Ç≈")]
        public int spawnValue;

        public ShoutAttackSettings(GameObject prefab, int maxSpawnValue)
        {
            this.prefab = prefab;
            this.maxSpawnValue = maxSpawnValue;
            this.spawnValue = 0;
        }
    }

    public ShoutAttackSettings shoutAttackSettings;

    public void ShoutAttackInitialize()
    {
        shoutAttackSettings.spawnValue = 0;
    }

    public void ShoutAttack()
    {
        // ç≈ëÂê∂ê¨êîÇ…íBÇµÇƒÇ¢ÇÈÇ©
        if(shoutAttackSettings.spawnValue < shoutAttackSettings.maxSpawnValue)
        {
            // ê∂ê¨êîâ¡éZ
            shoutAttackSettings.spawnValue++;

            // ê∂ê¨à íuÇê›íË
            GameObject enemy = GameObject.FindWithTag("Enemy");
            Vector3 spawnPos = enemy.transform.position;

            // ê∂ê¨Ç∑ÇÈ
            Instantiate(shoutAttackSettings.prefab, spawnPos, Quaternion.identity);
        }
    }
}
