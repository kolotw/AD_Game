using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class 資源增減 : MonoBehaviour
{
    public TextMeshPro 資源文字;
    string 符號;
    public GameObject 小兵;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void 處理字串()
    {
        符號 = 資源文字.text;
        char firstChar = 符號[0];
        string num = 符號.Substring(1);
        int number = int.Parse(num);

        switch (firstChar.ToString())
        {
            case "+":
                for(int i = 0; i< number; i++)
                {
                    Instantiate(小兵, this.transform.position, Quaternion.identity);
                }                
                break; 
            case "-":
                GameObject[] gg = GameObject.FindGameObjectsWithTag("小兵");              
                if (gg != null)
                {
                    if(number >  gg.Length) number = gg.Length;
                    for (int i = 0; i < number; i++)
                    {
                        Destroy(gg[i]);
                    }
                }                
                break;
            default:
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            處理字串();
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
