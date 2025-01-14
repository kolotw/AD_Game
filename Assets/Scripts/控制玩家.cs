using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class 控制玩家 : MonoBehaviour
{
    public float speed = 30.0f;
    public GameObject 我的子彈;
    public Transform 發射點;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("發射子彈", 1f, 0.3f);
    }
    void 發射子彈()
    {
        GameObject bb = Instantiate(我的子彈,發射點.position, Quaternion.identity);
        Destroy(bb,2f);
        bb.GetComponent<Rigidbody>().AddForce(Vector3.forward * 1000);
    }

    // Update is called once per frame
    void Update()
    {
        //滑鼠移動法 獲取滑鼠位置並轉換為 Ray
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 使用 Raycast 檢測，確保射線擊中目標圖層
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "Player") return;
                // 移動 targetObject 到擊中的位置
                Vector3 targetPosition = hit.point;
                targetPosition.y = 0;
                targetPosition.z = targetPosition.z + 1;
                this.transform.position = targetPosition;
            }
        }
        
        //鍵盤移動法
        { 
        if (Input.GetKey(KeyCode.A)  || Input.GetKey(KeyCode.LeftArrow)) 
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) 
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) 
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) 
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "障礙物") return;
        int number = 0;
        number = collision.gameObject.GetComponent<敵人的行為>().血量;
        if(collision.transform.tag == "敵人")
        {
            GameObject[] gg = GameObject.FindGameObjectsWithTag("小兵");
            collision.gameObject.GetComponent<敵人的行為>().血量 = number - gg.Length;
            if (gg != null)
            {
                if (number > gg.Length) number = gg.Length;
                for (int i = 0; i < number; i++)
                {
                    Destroy(gg[i]);
                }
            }
            
        }
    }
}
