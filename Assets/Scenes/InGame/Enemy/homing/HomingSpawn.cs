using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings homingAttackSettings;

    public void HomingAttack()
    {
        homingAttackSettings.timer += Time.deltaTime;

        if (homingAttackSettings.timer >= homingAttackSettings.spawnInterval)
        {
            homingAttackSettings.timer = 0f;
            GameObject homing = Instantiate(homingAttackSettings.prefab, transform.position, Quaternion.identity);
        }
    }
}
