using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings MagmaStickySettings;

    public void MagmaSticky()
    {
        MagmaStickySettings.timer += Time.deltaTime;

        if (MagmaStickySettings.timer >= MagmaStickySettings.spawnInterval)
        {
            MagmaStickySettings.timer = 0f;
            GameObject MagmaSticky = Instantiate(MagmaStickySettings.prefab, transform.position, Quaternion.identity);
        }
    }
}
