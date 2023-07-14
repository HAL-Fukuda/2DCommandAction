using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings TentacleSettings;
    private Vector3 tentaclePosition;

    public GameObject EnemyTentacle;

    private GameObject Tentacleobj;
    private bool Tentacleflg = true;

    void GetPositionToTentacle()
    {
        GameObject EnemyObject = GameObject.Find("GoblinSoldier(Clone)");

        tentaclePosition = EnemyObject.transform.position;

        tentaclePosition.z = 0.0f;
    }

    void TentacleobjDestroy()
    {
        Destroy(Tentacleobj);
    }

    void TentacleflgTrue()
    {
        Tentacleflg = true;
    }

    void Tentacle()
    {
        Tentacleobj.transform.DORotate(new Vector3(0, 0, -360), 1.5f, RotateMode.FastBeyond360)
            .SetEase(Ease.InOutBack)
            .OnComplete(TentacleobjDestroy);
    }

    public void TentacleAttack()
    {
        if (Tentacleflg)
        {
            Tentacleflg = false;
            GetPositionToTentacle();

            spawnPos = new Vector3(tentaclePosition.x, tentaclePosition.y, 0.0f);
            Tentacleobj = Instantiate(TentacleSettings.prefab, spawnPos, Quaternion.identity);

            Invoke("Tentacle", 0.3f);
            Invoke("TentacleflgTrue", TentacleSettings.spawnInterval);
        }
    }
}
