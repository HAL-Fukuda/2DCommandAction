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
        // LifeManager�X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g���擾����
        GameObject EnemyObject = GameObject.FindWithTag("Enemy");

        // LifeManager�R���|�[�l���g���擾����
        if (EnemyObject != null)
        {
            enemy = EnemyObject.GetComponent<Enemy>();

            HP = enemy.SendEnemyHp();   // �G��HP�����������Ă���

            GetEnemyHp(HP);     // �G��HP����

            slider.maxValue = 1;

            //Debug.Log("��񂾂�");

            FindAlready = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // �G���o�ĂȂ�����HP���擾���悤�Ƃ�����̉���
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
