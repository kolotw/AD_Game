using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 遊戲管理員 : MonoBehaviour
{
    public Text 結果;
    int 敵人數量 = 0;
    // Start is called before the first frame update
    void Start()
    {
        結果.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        敵人數量 = GameObject.FindGameObjectsWithTag("敵人").Length;
        if(敵人數量 <= 0)
        {
            結果.text = "勝";
        }
    }
}
