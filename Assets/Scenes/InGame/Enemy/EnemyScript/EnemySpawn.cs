using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyMgr : MonoBehaviour
{
    //3体だけ出す用(ステージごとに設定が必要)
    [SerializeField] private GameObject enemyObj1;
    [SerializeField] private GameObject enemyObj2;
    [SerializeField] private GameObject enemyObj3;

    public int enemyNum;

    private GameObject enemy; // 今生成されているエネミー
    
    void EnemySpawnInitialize()
    {
        
    }
    
    void EnemySpawnUpdate()
    {
        
    }

    public int SpawnEnemy(int enemyNum)  //3体だけ出す用
    {
        switch (enemyNum)
        {
            case 0:
                FirstEnemySpawn();
                break;
            case 1:
                SecondEnemySpawn();
                break;
            case 2:
                ThirdEnemySpawn();
                break;
        }

        return enemyNum;
    }
    void FirstEnemySpawn()
    {
        enemy = Instantiate(enemyObj1, new Vector3(0, 4, 0), enemyObj1.transform.rotation);
    }
    void SecondEnemySpawn()
    {
        enemy = Instantiate(enemyObj2, new Vector3(0, 4, 0), enemyObj2.transform.rotation);
    }
    void ThirdEnemySpawn()
    {
        enemy = Instantiate(enemyObj3, new Vector3(0, 4, 0), enemyObj3.transform.rotation);
    }
}
