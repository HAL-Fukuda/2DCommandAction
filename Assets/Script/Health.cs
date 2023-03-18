using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Health : MonoBehaviour
{
    public int hp_current;  //���݂�HP
    public int hp_max;      //HP�̍ő�l

    public UnityEvent<int> OnHealthChange = new UnityEvent<int>();



    // Start is called before the first frame update
    void Start()
    {
        OnHealthChange.Invoke(hp_current);  //�C���X�y�N�^�[�r���[�œ��͂��ꂽ�l�𑗂�
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            hp_current -= 1;
            OnHealthChange.Invoke(hp_current);  //hp_current�̒l�𑗂�
            Debug.Log("���C�t:�@-�P");
        }
    }

    public void Damege(int _iParam)
    {
        hp_current -= Mathf.Abs(_iParam);  //HP�񕜂̑j�~

        OnHealthChange.Invoke(hp_current);  //hp_current�̒l�𑗂�
    }

   
}
