using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class 小兵的行為 : MonoBehaviour
{
    NavMeshAgent 導航;
    Transform 目標;
    // Start is called before the first frame update
    void Start()
    {
        導航 = GetComponent<NavMeshAgent>();
        目標 = GameObject.FindGameObjectWithTag("Player").transform;        
    }

    // Update is called once per frame
    void Update()
    {
        if (目標 == null) return;
        //if(導航.remainingDistance < 導航.stoppingDistance)
            導航.SetDestination(目標.position);        
    }
}

