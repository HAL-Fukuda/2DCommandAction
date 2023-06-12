using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    private Enemy enemy;

    private int HP;
    private int MAX_HP;
    private int NOW_HP;

    private bool FindAlready = false;

    public Slider slider;


    public void GetEnemyHp(int Hp)
    {
        MAX_HP = Hp;
        NOW_HP = Hp;
    }

    public void SetNowHp(int Hp)
    {
        NOW_HP = Hp;
    }

    // Start is called before the first frame update
    void Start()
    {
        // LifeManagerスクリプトがアタッチされているオブジェクトを取得する
        GameObject EnemyObject = GameObject.FindWithTag("Enemy");

        // LifeManagerコンポーネントを取得する
        if (EnemyObject != null)
        {
            enemy = EnemyObject.GetComponent<Enemy>();

            HP = enemy.SendEnemyHp();   // 敵のHPを引っ張ってくる

            GetEnemyHp(HP);     // 敵のHPを代入

            slider.maxValue = 1;

            //Debug.Log("一回だけ");

            FindAlready = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 敵が出てない時にHPを取得しようとする問題の解決
        if (FindAlready == false)
        {
            Start();
        }

        HP = enemy.SendEnemyHp();
        SetNowHp(HP);

        slider.value = (float)NOW_HP / (float)MAX_HP;

        //Debug.Log(MAX_HP);
        //Debug.Log(NOW_HP);
    }
}
