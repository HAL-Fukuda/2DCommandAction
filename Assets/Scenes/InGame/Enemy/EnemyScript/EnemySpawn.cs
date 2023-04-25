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

    //ここから追加分
    [SerializeField] private GameObject grifinPrefab;
    [SerializeField] private GameObject goblinArcherPrefab;
    [SerializeField] private GameObject goblinKingPrefab;
    [SerializeField] private GameObject gobllinSoldierPrefab;
    [SerializeField] private GameObject normalGoblinPrefab;
    [SerializeField] private GameObject golem1Prefab;
    [SerializeField] private GameObject golem2Prefab;
    [SerializeField] private GameObject skeleton1Prefab;
    [SerializeField] private GameObject skeleton2Prefab;
    [SerializeField] private GameObject skeleton3Prefab;
    [SerializeField] private GameObject spiderPrefab;
    [SerializeField] private GameObject slime1Prefab;
    [SerializeField] private GameObject slime2Prefab;
    //[SerializeField] private GameObject zombiePrefab;
    [SerializeField] private GameObject demon1Prefab;
    [SerializeField] private GameObject demon2Prefab;
    [SerializeField] private GameObject troll1Prefab;
    [SerializeField] private GameObject troll2Prefab;
    [SerializeField] private GameObject dragon1Prefab;
    [SerializeField] private GameObject dragon2Prefab;
    [SerializeField] private GameObject dragon3Prefab;
    [SerializeField] private GameObject dragon4Prefab;
    [SerializeField] private GameObject fennelPrefab;
    [SerializeField] private GameObject lizardPrefab;
    [SerializeField] private GameObject suzakuPrefab;
    [SerializeField] private GameObject machine1Prefab;
    [SerializeField] private GameObject machine2Prefab;
    //[SerializeField] private GameObject wolfPrefab;
    [SerializeField] private GameObject genbuPrefab;
    [SerializeField] private GameObject byakoPrefab;
    [SerializeField] private GameObject seiryuPrefab;
    [SerializeField] private GameObject ogrePrefab;
    //ここまで追加分

    //public int num;
    private GameObject enemy; // 今生成されているエネミー
    
    void EnemySpawnInitialize()
    {
        
    }
    
    void EnemySpawnUpdate()
    {
        
    }

    public Enemy.eEnemyType SpawnEnemy(Enemy.eEnemyType enemyType)
    {
        //Debug.Log("spawn");
        //switch (enemyType)
        //{
        //    case Enemy.eEnemyType.Ogre:
        //        DemonSpawn();
        //        break;
        //    case Enemy.eEnemyType.Dragon3:
        //        DragonSpawn();
        //        break;
        //    case Enemy.eEnemyType.Goblin:
        //        GoblinSpawn();
        //        break;
        //    case Enemy.eEnemyType.Skeleton1:
        //        SkeltonSpawn();
        //        break;
        //    case Enemy.eEnemyType.Slime1:
        //        SlimeSpawn();
        //        break;
        //    case Enemy.eEnemyType.Wolf:
        //        WolfSpawn();
        //        break;
        //    case Enemy.eEnemyType.Zombie:
        //        ZombieSpawn();
        //        break;
        //}
        switch (enemyType)
        {
            case Enemy.eEnemyType.GoblinArcher:
                GoblinArcherSpawn();
                break;
            case Enemy.eEnemyType.GoblinKing:
                GoblinKingSpawn();
                break;
            case Enemy.eEnemyType.GoblinSoldier:
                GoblinSoldierSpawn();
                break;
            case Enemy.eEnemyType.Goblin:
                GoblinSpawn();
                break;
            case Enemy.eEnemyType.Golem1:
                Golem1Spawn();
                break;
            case Enemy.eEnemyType.Golem2:
                Golem2Spawn();
                break;
            case Enemy.eEnemyType.Skeleton1:
                Skeleton1Spawn();
                break;
            case Enemy.eEnemyType.Skeleton2:
                Skeleton2Spawn();
                break;
            case Enemy.eEnemyType.Skeleton3:
                Skeleton3Spawn();
                break;
            case Enemy.eEnemyType.Spider:
                SpiderSpawn();
                break;
            case Enemy.eEnemyType.Slime1:
                Slime1Spawn();
                break;
            case Enemy.eEnemyType.Slime2:
                Slime2Spawn();
                break;
            case Enemy.eEnemyType.Grifin:
                GrifinSpawn();
                break;
            case Enemy.eEnemyType.Zombie:
                ZombieSpawn();
                break;
            case Enemy.eEnemyType.Demon1:
                Demon1Spawn();
                break;
            case Enemy.eEnemyType.Demon2:
                Demon2Spawn();
                break;
            case Enemy.eEnemyType.Troll1:
                Troll1Spawn();
                break;
            case Enemy.eEnemyType.Troll2:
                Troll2Spawn();
                break;
            case Enemy.eEnemyType.Dragon1:
                Dragon1Spawn();
                break;
            case Enemy.eEnemyType.Dragon2:
                Dragon2Spawn();
                break;
            case Enemy.eEnemyType.Dragon3:
                Dragon3Spawn();
                break;
            case Enemy.eEnemyType.Dragon4:
                Dragon4Spawn();
                break;
            case Enemy.eEnemyType.Fennel:
                FennelSpawn();
                break;
            case Enemy.eEnemyType.Lizard:
                LizardSpawn();
                break;
            case Enemy.eEnemyType.Suzaku:
                SuzakuSpawn();
                break;
            case Enemy.eEnemyType.Machine1:
                Machine1Spawn();
                break;
            case Enemy.eEnemyType.Machine2:
                Machine2Spawn();
                break;
            case Enemy.eEnemyType.Wolf:
                WolfSpawn();
                break;
            case Enemy.eEnemyType.Genbu:
                GenbuSpawn();
                break;
            case Enemy.eEnemyType.Byako:
                ByakoSpawn();
                break;
            case Enemy.eEnemyType.Seiryu:
                SeiryuSpawn();
                break;
            case Enemy.eEnemyType.Ogre:
                OgreSpawn();
                break;
        }

        return enemyType;
    }

    //void DemonSpawn()
    //{
    //    enemy = Instantiate(demonPrefab, new Vector3(0,4,0), demonPrefab.transform.rotation);
    //}
    //void DragonSpawn()
    //{
    //    enemy = Instantiate(dragonPrefab, new Vector3(0, 4, 0), dragonPrefab.transform.rotation);
    //}
    //void GoblinSpawn()
    //{
    //    enemy = Instantiate(goblinPrefab, new Vector3(0, 4, 0), goblinPrefab.transform.rotation);
    //}
    //void SkeltonSpawn()
    //{
    //    enemy = Instantiate(skeletonPrefab, new Vector3(0, 4, 0), skeletonPrefab.transform.rotation);
    //}
    //void SlimeSpawn()
    //{
    //    enemy = Instantiate(slimePrefab, new Vector3(0, 4, 0), slimePrefab.transform.rotation);
    //}
    //void WolfSpawn()
    //{
    //    enemy = Instantiate(wolfPrefab, new Vector3(0, 4, 0), wolfPrefab.transform.rotation);
    //}
    //void WolfManSpawn()
    //{
    //    enemy = Instantiate(wolfmanPrefab, new Vector3(0, 4, 0), wolfmanPrefab.transform.rotation);
    //}
    //void ZombieSpawn()
    //{
    //    enemy = Instantiate(zombiePrefab, new Vector3(0, 4, 0), zombiePrefab.transform.rotation);
    //}

    void GoblinArcherSpawn()
    {
        enemy = Instantiate(goblinArcherPrefab, new Vector3(0, 4, 0), goblinArcherPrefab.transform.rotation);
    }
    void GoblinKingSpawn()
    {
        enemy = Instantiate(goblinKingPrefab, new Vector3(0, 4, 0), goblinKingPrefab.transform.rotation);
    }
    void GoblinSoldierSpawn()
    {
        enemy = Instantiate(gobllinSoldierPrefab, new Vector3(0, 4, 0), gobllinSoldierPrefab.transform.rotation);
    }
    void GoblinSpawn()
    {
        enemy = Instantiate(normalGoblinPrefab, new Vector3(0, 4, 0), normalGoblinPrefab.transform.rotation);
    }
    void Golem1Spawn()
    {
        enemy = Instantiate(golem1Prefab, new Vector3(0, 4, 0), golem1Prefab.transform.rotation);
    }
    void Golem2Spawn()
    {
        enemy = Instantiate(golem2Prefab, new Vector3(0, 4, 0), golem2Prefab.transform.rotation);
    }
    void Skeleton1Spawn()
    {
        enemy = Instantiate(skeleton1Prefab, new Vector3(0, 4, 0), skeleton1Prefab.transform.rotation);
    }
    void Skeleton2Spawn()
    {
        enemy = Instantiate(skeleton2Prefab, new Vector3(0, 4, 0), skeleton2Prefab.transform.rotation);
    }
    void Skeleton3Spawn()
    {
        enemy = Instantiate(skeleton3Prefab, new Vector3(0, 4, 0), skeleton3Prefab.transform.rotation);
    }
    void SpiderSpawn()
    {
        enemy = Instantiate(spiderPrefab, new Vector3(0, 4, 0), spiderPrefab.transform.rotation);
    }
    void Slime1Spawn()
    {
        enemy = Instantiate(slime1Prefab, new Vector3(0, 4, 0), slime1Prefab.transform.rotation);
    }
    void Slime2Spawn()
    {
        enemy = Instantiate(slime2Prefab, new Vector3(0, 4, 0), slime2Prefab.transform.rotation);
    }
    void GrifinSpawn()
    {
        enemy = Instantiate(grifinPrefab, new Vector3(0, 4, 0), grifinPrefab.transform.rotation);
    }
    void ZombieSpawn()
    {
        enemy = Instantiate(zombiePrefab, new Vector3(0, 4, 0), zombiePrefab.transform.rotation);
    }
    void Demon1Spawn()
    {
        enemy = Instantiate(demon1Prefab, new Vector3(0, 4, 0), demon1Prefab.transform.rotation);
    }
    void Demon2Spawn()
    {
        enemy = Instantiate(demon2Prefab, new Vector3(0, 4, 0), demon2Prefab.transform.rotation);
    }
    void Troll1Spawn()
    {
        enemy = Instantiate(troll1Prefab, new Vector3(0, 4, 0), troll1Prefab.transform.rotation);
    }
    void Troll2Spawn()
    {
        enemy = Instantiate(troll2Prefab, new Vector3(0, 4, 0), troll2Prefab.transform.rotation);
    }
    void Dragon1Spawn()
    {
        enemy = Instantiate(dragon1Prefab, new Vector3(0, 4, 0), dragon1Prefab.transform.rotation);
    }
    void Dragon2Spawn()
    {
        enemy = Instantiate(dragon2Prefab, new Vector3(0, 4, 0), dragon2Prefab.transform.rotation);
    }
    void Dragon3Spawn()
    {
        enemy = Instantiate(dragon3Prefab, new Vector3(0, 4, 0), dragon3Prefab.transform.rotation);
    }
    void Dragon4Spawn()
    {
        enemy = Instantiate(dragon4Prefab, new Vector3(0, 4, 0), dragon4Prefab.transform.rotation);
    }
    void FennelSpawn()
    {
        enemy = Instantiate(fennelPrefab, new Vector3(0, 4, 0), fennelPrefab.transform.rotation);
    }
    void LizardSpawn()
    {
        enemy = Instantiate(lizardPrefab, new Vector3(0, 4, 0), lizardPrefab.transform.rotation);
    }
    void SuzakuSpawn()
    {
        enemy = Instantiate(suzakuPrefab, new Vector3(0, 4, 0), suzakuPrefab.transform.rotation);
    }
    void Machine1Spawn()
    {
        enemy = Instantiate(machine1Prefab, new Vector3(0, 4, 0), machine1Prefab.transform.rotation);
    }
    void Machine2Spawn()
    {
        enemy = Instantiate(machine2Prefab, new Vector3(0, 4, 0), machine2Prefab.transform.rotation);
    }
    void WolfSpawn()
    {
        enemy = Instantiate(wolfPrefab, new Vector3(0, 4, 0), wolfPrefab.transform.rotation);
    }
    void GenbuSpawn()
    {
        enemy = Instantiate(genbuPrefab, new Vector3(0, 4, 0), genbuPrefab.transform.rotation);
    }
    void ByakoSpawn()
    {
        enemy = Instantiate(byakoPrefab, new Vector3(0, 4, 0), byakoPrefab.transform.rotation);
    }
    void SeiryuSpawn()
    {
        enemy = Instantiate(seiryuPrefab, new Vector3(0, 4, 0), seiryuPrefab.transform.rotation);
    }
    void OgreSpawn()
    {
        enemy = Instantiate(ogrePrefab, new Vector3(0, 4, 0), ogrePrefab.transform.rotation);
    }
}
