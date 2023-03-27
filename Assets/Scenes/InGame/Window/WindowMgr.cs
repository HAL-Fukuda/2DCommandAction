using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class WindowMgr : MonoBehaviour
{ 
    // コンストラクタを private にすることで、クラスの外部からのインスタンス生成を防ぐ（シングルトンパターン）
    private WindowMgr() { }

    // このクラスのインスタンス（他スクリプトから参照するときはこのインスタンスを介して行う）
    private static WindowMgr instance = null;

    public static WindowMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WindowMgr();
            }
            return instance;
        }
    }

    // 変数定義-------------------------


    // 関数定義-------------------------

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
