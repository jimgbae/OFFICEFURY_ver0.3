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

    //�÷��̾�� �浹�ϸ� �� ��� �ڻ��ϰ� ���ͻ���
    //�̶� ����� �־����� �׳� �浹�ϸ� �������ְ� ����
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
