using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    GameObject player;  //�÷��̾� ������Ʈ
    NavMeshAgent nav;   //�׺�޽�

    public bool isMoving = true;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        nav=GetComponent<NavMeshAgent>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
