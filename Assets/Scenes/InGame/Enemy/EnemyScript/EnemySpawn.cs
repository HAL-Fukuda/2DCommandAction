using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyMgr : MonoBehaviour
{
    //生成する敵を設定する箱(ステージごとに設定が必要)
    [SerializeField] private GameObject enemyObj1;
    [SerializeField] private GameObject enemyObj2;
    [SerializeField] private GameObject enemyObj3;

    public int enemyNum;  //何番目の敵を生成するかを指定する変数

    private GameObject enemy; // 生成するエネミー
    
    public int SpawnEnemy(int enemyNum)  //敵を生成する
    {
        switch (enemyNum)  //指定した番号の敵を生成する
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

    //敵生成の関数
    void FirstEnemySpawn()  //一体目
    {
        enemy = Instantiate(enemyObj1, new Vector3(0, 4, 0), enemyObj1.transform.rotation);
    }
    void SecondEnemySpawn()  //二体目
    {
        enemy = Instantiate(enemyObj2, new Vector3(0, 4, 0), enemyObj2.transform.rotation);
    }
    void ThirdEnemySpawn()  //三体目
    {
        enemy = Instantiate(enemyObj3, new Vector3(0, 4, 0), enemyObj3.transform.rotation);
    }
}
