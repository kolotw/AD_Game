using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 場景的移動 : MonoBehaviour
{
    Vector3 pos;
    public float moveSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos.z -= moveSpeed * Time.deltaTime;
        transform.position = pos;
    }
}
