using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Health : MonoBehaviour
{
    public int hp_current;  //現在のHP
    public int hp_max;      //HPの最大値

    public UnityEvent<int> OnHealthChange = new UnityEvent<int>();



    // Start is called before the first frame update
    void Start()
    {
        OnHealthChange.Invoke(hp_current);  //インスペクタービューで入力された値を送る
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            hp_current -= 1;
            OnHealthChange.Invoke(hp_current);  //hp_currentの値を送る
            Debug.Log("ライフ:　-１");
        }
    }

    public void Damege(int _iParam)
    {
        hp_current -= Mathf.Abs(_iParam);  //HP回復の阻止

        OnHealthChange.Invoke(hp_current);  //hp_currentの値を送る
    }

   
}
