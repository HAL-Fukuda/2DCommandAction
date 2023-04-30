using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyMgr : MonoBehaviour
{
    //��������G��ݒ肷�锠(�X�e�[�W���Ƃɐݒ肪�K�v)
    [SerializeField] private GameObject enemyObj1;
    [SerializeField] private GameObject enemyObj2;
    [SerializeField] private GameObject enemyObj3;

    public int enemyNum;  //���Ԗڂ̓G�𐶐����邩���w�肷��ϐ�

    private GameObject enemy; // ��������G�l�~�[
    
    public int SpawnEnemy(int enemyNum)  //�G�𐶐�����
    {
        switch (enemyNum)  //�w�肵���ԍ��̓G�𐶐�����
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

    //�G�����̊֐�
    void FirstEnemySpawn()  //��̖�
    {
        enemy = Instantiate(enemyObj1, new Vector3(0, 4, 0), enemyObj1.transform.rotation);
    }
    void SecondEnemySpawn()  //��̖�
    {
        enemy = Instantiate(enemyObj2, new Vector3(0, 4, 0), enemyObj2.transform.rotation);
    }
    void ThirdEnemySpawn()  //�O�̖�
    {
        enemy = Instantiate(enemyObj3, new Vector3(0, 4, 0), enemyObj3.transform.rotation);
    }
}
