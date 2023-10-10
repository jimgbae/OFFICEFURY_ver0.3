using FMODPlus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomMob : BaseMonster
{
    [SerializeField] ParticleSystem explosion;
    float distance;
    public float detect;

    public float boomTime;
    public float boomRange;


    [SerializeField] FMODAudioSource explosionsfx;

    public bool boomCheck = false;

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

        //�÷��̾���� �Ÿ�
        distance = Vector3.Distance(player.transform.position, monster.transform.position);

        //�÷��̾ �������� ���Դ��� üũ, �������� ����� ��������
        if (distance <= detect)
        {
            if (boomCheck == false)
            {
                Debug.Log("����!");
                isMoving = false;
                //anima.SetBool("Boom", true);
                Invoke("Boom", boomTime);
                boomCheck = true;
            }
        }
    }

    private void ExplosionEffect()
    {
        explosion.Play();
    }

    private void ExplosionSfx()
    {
        explosionsfx.Play();
    }

    protected override void Dead()
    {
        ExplosionEffect();
        S_Manager.GameMonsterCount--;
        Debug.Log("����");
        
        player.GetComponent<BasePlayer>().coin += dropCoin;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        Destroy(this.gameObject, 3f);
    }

    //���߹������� ������ ������
    void Boom() {
        ExplosionEffect();
        ExplosionSfx();
        if (distance <= boomRange) {
            player.GetComponent<BasePlayer>().hp = player.GetComponent<BasePlayer>().hp - damage;
        }
        S_Manager.m_compCount--;
        Dead();
    }
}
