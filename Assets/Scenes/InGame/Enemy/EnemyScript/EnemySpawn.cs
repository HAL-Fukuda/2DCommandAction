using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyMgr : MonoBehaviour
{
    [SerializeField] private GameObject demonPrefab;
    [SerializeField] private GameObject dragonPrefab;
    [SerializeField] private GameObject goblinPrefab;
    [SerializeField] private GameObject skeletonPrefab;
    [SerializeField] private GameObject slimePrefab;
    [SerializeField] private GameObject soldierPrefab;
    [SerializeField] private GameObject wolfPrefab;
    [SerializeField] private GameObject wolfmanPrefab;
    [SerializeField] private GameObject zombiePrefab;

    //public int num;
    private GameObject enemy; // 今生成されているエネミー
    
    void EnemySpawnInitialize()
    {
        
    }
    
    void EnemySpawnUpdate()
    {
        
    }

    //public void EnemySpawn()
    //{
    //    //num = Random.Range(0, 9);

    //    if (num == 0)
    //    {
    //        DemonSpawn();
    //    }
    //    else if (num == 1)
    //    {
    //        DragonSpawn();
    //    }
    //    else if (num == 2)
    //    {
    //        GoblinSpawn();
    //    }
    //    else if (num == 3)
    //    {
    //        SkeltonSpawn();
    //    }
    //    else if (num == 4)
    //    {
    //        SlimeSpawn();
    //    }
    //    else if (num == 5)
    //    {
    //        WolfSpawn();
    //    }
    //    else if (num == 6)
    //    {
    //        SkeltonSpawn();
    //    }
    //    else if (num == 7)
    //    {
    //        WolfManSpawn();
    //    }
    //    else if (num == 8)
    //    {
    //        ZombieSpawn();
    //    }

    //}

    public Enemy.eEnemyType SpawnEnemy(Enemy.eEnemyType enemyType)
    {
        switch (enemyType)
        {
            case Enemy.eEnemyType.Demon:
                DemonSpawn();
                break;
            case Enemy.eEnemyType.Dragon:
                DragonSpawn();
                break;
            case Enemy.eEnemyType.Goblin:
                GoblinSpawn();
                break;
            case Enemy.eEnemyType.Skeleton:
                SkeltonSpawn();
                break;
            case Enemy.eEnemyType.Slime:
                SlimeSpawn();
                break;
            case Enemy.eEnemyType.Soldier:
                Debug.Log("外出中");
                break;
            case Enemy.eEnemyType.Wolf:
                WolfSpawn();
                break;
            case Enemy.eEnemyType.WolfMan:
                WolfManSpawn();
                break;
            case Enemy.eEnemyType.Zombie:
                ZombieSpawn();
                break;
        }
        return enemyType;
    }

    void DemonSpawn()
    {
        enemy = Instantiate(demonPrefab, new Vector3(0,4,0), demonPrefab.transform.rotation);
    }
    void DragonSpawn()
    {
        enemy = Instantiate(dragonPrefab, new Vector3(0, 4, 0), dragonPrefab.transform.rotation);
    }
    void GoblinSpawn()
    {
        enemy = Instantiate(goblinPrefab, new Vector3(0, 4, 0), goblinPrefab.transform.rotation);
    }
    void SkeltonSpawn()
    {
        enemy = Instantiate(skeletonPrefab, new Vector3(0, 4, 0), skeletonPrefab.transform.rotation);
    }
    void SlimeSpawn()
    {
        enemy = Instantiate(slimePrefab, new Vector3(0, 4, 0), slimePrefab.transform.rotation);
    }
    void WolfSpawn()
    {
        enemy = Instantiate(wolfPrefab, new Vector3(0, 4, 0), wolfPrefab.transform.rotation);
    }
    void WolfManSpawn()
    {
        enemy = Instantiate(wolfmanPrefab, new Vector3(0, 4, 0), wolfmanPrefab.transform.rotation);
    }
    void ZombieSpawn()
    {
        enemy = Instantiate(zombiePrefab, new Vector3(0, 4, 0), zombiePrefab.transform.rotation);
    }
}
