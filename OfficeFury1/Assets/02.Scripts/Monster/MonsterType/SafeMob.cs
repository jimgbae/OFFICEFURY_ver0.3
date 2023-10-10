using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SafeMob : BaseMonster
{
    protected Vector3 destination;
    float distance;
    public float detect;

    public float deleteTime;

    public float jumpSpeed;

    protected override void Awake()
    {
        base.Awake();
    }


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        isMoving = false;
        Invoke("DeleteRun",deleteTime);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        //�÷��̾���� �Ÿ�
        distance = Vector3.Distance(player.transform.position, monster.transform.position);

        //�÷��̾ �Ÿ����� ������ �÷��̾�ݴ�������� ������
        if (distance <= detect)
        {
            Debug.Log("����!");
            anima.SetBool("Jump", true);
            nav.speed = jumpSpeed;
            destination = new Vector3(transform.position.x - player.transform.position.x, 0f, transform.position.z - player.transform.position.z).normalized;
            nav.SetDestination(transform.position + destination * jumpSpeed);
        }
        else {
            anima.SetBool("Jump", false);
            isMoving = true;
            nav.speed = 1f;
        }
    }



    void DeleteRun() {
        S_Manager.m_safeCount--;
        
        isDead = true;
    }
}
