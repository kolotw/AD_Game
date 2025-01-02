using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class 資源增減 : MonoBehaviour
{
    public GameObject[] 資源符號;
    public Material[] mat; //mat0 blue, mat1 red
    public TextMeshPro 資源文字;
    string 符號;
    public GameObject 小兵;
    // Start is called before the first frame update
    void Start()
    {
        資源數增減();
    }
    void 處理字串()
    {
        符號 = 資源文字.text;
        char firstChar = 符號[0];
        string num = 符號.Substring(1);
        int number = int.Parse(num);
        int pawn = 0;
        int total = 0;
        switch (firstChar.ToString())
        {
            case "+":
                for (int i = 0; i< number; i++)
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
            case "x":                
                pawn = GameObject.FindGameObjectsWithTag("小兵").Length;
                total = 0;
                if (pawn == 0) pawn = 1;
                if(pawn > 0)
                {
                    total = (pawn * number) - pawn; // 2*20=40
                    for (int i = 0;i < total; i++)
                    {
                        Instantiate(小兵, this.transform.position, Quaternion.identity);
                    }
                }
                break;
            case "/":
                // 8 / 3 = 2...2 ..... 8-x = 2
                GameObject[] ga = GameObject.FindGameObjectsWithTag("小兵");
                pawn = ga.Length;
                total = Mathf.RoundToInt(pawn / number);
                total = ga.Length - total;
                for (int i = 0; i < total; i++)
                {
                    Destroy (ga[i]);
                }
                break;
            default:
                break;
        }
    }

    void 資源數增減()
    {
        符號 = 資源文字.text;
        char firstChar = 符號[0];
        string num = 符號.Substring(1);
        int number = int.Parse(num);        
        switch (firstChar.ToString())
        {
            case "+":
                資源符號[0].SetActive(true);
                資源符號[1].SetActive(false);
                資源符號[2].SetActive(false);
                資源符號[3].SetActive(false);
                number++;
                資源文字.text = "+" + number.ToString();
                break;
            case "-":
                資源符號[0].SetActive(false);
                資源符號[1].SetActive(true);
                資源符號[2].SetActive(false);
                資源符號[3].SetActive(false);
                if (firstChar.ToString() == "-") number = number * -1;
                number++;
                if(number >= 0)
                {
                    資源文字.text = "+" + number.ToString();
                    this.GetComponent<Renderer>().material = mat[0];
                }                    
                else
                    資源文字.text = number.ToString();
                break;
            case "x":
                資源符號[0].SetActive(false);
                資源符號[1].SetActive(false);
                資源符號[2].SetActive(true);
                資源符號[3].SetActive(false);
                break;
            case "/":
                資源符號[0].SetActive(false);
                資源符號[1].SetActive(false);
                資源符號[2].SetActive(false);
                資源符號[3].SetActive(true);
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
            Destroy(this.gameObject);
        }
        else if(other.tag == "玩家的子彈")
        {
            資源數增減();
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
