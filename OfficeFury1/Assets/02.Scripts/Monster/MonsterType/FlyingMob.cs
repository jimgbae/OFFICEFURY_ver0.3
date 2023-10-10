using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMob : BaseMonster
{
    public GameObject spawnMonster;

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
        base.Update();
    }

    //플레이어와 충돌하면 그 즉시 자살하고 몬스터생성
    //이란 기능이 있었으나 그냥 충돌하면 데미지주고 삭제
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.gameObject.tag == "Player") {
            //Instantiate(spawnMonster, monster.transform.position, monster.transform.rotation);
            S_Manager.m_flyCount--;
            isDead = true;
        }
    }
}
