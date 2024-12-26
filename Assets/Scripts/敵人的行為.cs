using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 敵人的行為 : MonoBehaviour
{
    public int 血量 = 99 ;
    int 原血量;
    public GameObject 血條;
    public TextMeshPro 血量文字;
    // Start is called before the first frame update
    void Start()
    {

        血量文字.text = 血量.ToString();
        原血量 = 血量;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if((collision.transform.tag == "玩家的子彈") || (collision.transform.tag == "小兵"))
        {            
            Destroy(collision.gameObject);
            血量--;            
        }

        if (血量 <= 0) Destroy(this.gameObject);
        血量文字.text = 血量.ToString();
        float 血的比例 = (float)血量 / (float)原血量;
        血條.transform.localScale = new Vector3(血的比例, 1, 1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
