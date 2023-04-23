using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings BindAttackSettings;

    public void BindAttack()
    {
        BindAttackSettings.timer += Time.deltaTime;

        if (BindAttackSettings.timer >= BindAttackSettings.spawnInterval)
        {
            BindAttackSettings.timer = 0f;
            GameObject Bind = Instantiate(BindAttackSettings.prefab, transform.position, Quaternion.identity);
        }
    }
}
