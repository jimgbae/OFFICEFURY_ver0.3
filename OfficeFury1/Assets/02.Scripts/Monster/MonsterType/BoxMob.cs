using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMob : BaseMonster
{
    public GameObject[] dropItem;

    protected override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();   
    }

    // Update is called once per frame
    protected override void Update()
    {
        
        if (isDead == true) {
            S_Manager.m_boxCount--;
            int i = Random.Range(0, 3);
            Instantiate(dropItem[0], monster.transform.position, monster.transform.rotation);
        }

        base.Update();
    }
}
