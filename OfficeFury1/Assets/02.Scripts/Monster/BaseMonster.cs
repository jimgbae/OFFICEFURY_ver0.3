using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FMODPlus;
using static Unity.VisualScripting.Member;

public class BaseMonster : MonoBehaviour
{

    public float hp;
    public float speed;

    public bool invincibility = false;
    public float invincibilityTime = 0.5f;

    [SerializeField]FMODAudioSource[] source;

    public GameObject player;
    public GameObject fire;
    public GameObject monster;
    public NavMeshAgent nav;

    public Animator anima;

    [SerializeField] ParticleSystem firefx;
    [SerializeField] float BurnTime = 5f;
    float CurTime;
    float DotTime = 0;
    [SerializeField] bool isBurn;

    Renderer monsterColor;

    public float damage;

    public bool isDead = false;
    public float deathTime;
    public float dropCoin;

    public bool isMoving = true;


    protected virtual void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fire = GameObject.FindGameObjectWithTag("Fire");

        //anima = GetComponent<Animator>();

        nav = GetComponent<NavMeshAgent>();

        monsterColor = gameObject.GetComponent<Renderer>();
        isBurn = false;
        DotTime = 0;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        nav.speed = speed;
    }

    // Update is called once per frame
    protected virtual void Update()
    {

        //플레이어 추적여부
        if (isMoving == true)
        {
            nav.SetDestination(player.transform.position);
        }
        else { }

        //사망상태 확인
        if (isDead == false)
        {

            if (hp <= 0)
            {
                if (player.GetComponent<BasePlayer>().activeGauge < 100)
                    player.GetComponent<BasePlayer>().activeGauge += 5;
                else
                    player.GetComponent<BasePlayer>().activeGauge = 100;

                isDead = true;
                isMoving = false;
                nav.speed = 0;
            }
        }
        else if (isDead == true)
        {
            source[0].Stop();
            Invoke("Dead", deathTime);
            //anima.SetBool("Death", true);
        }

        if (isBurn)
            BurnDamage();
        else
            CurTime = 0;
    }

    private void BurnDamage()
    {
        //source[0].Play();
        CurTime += Time.deltaTime;
        DotTime += Time.deltaTime;
        if (DotTime > 0.5)
        {
            hp -= 1;
            DotTime = 0;
        }    
    }

    //죽으면 실행되는 함수
    protected virtual void Dead() {
        S_Manager.GameMonsterCount--;
        
        Debug.Log("죽음");
        player.GetComponent<BasePlayer>().coin += dropCoin;
        
        Destroy(monster);
    }

    void Destroy() {
        
    }

    protected virtual void InvincibilityClear()   //무적해제
    {
        monsterColor.material.color = Color.clear;
        invincibility = false;
    }


    protected virtual void OnTriggerEnter(Collider other)
    {
        
    }

    protected virtual void OnTriggerStay(Collider other) {

        if (other.gameObject.tag == "Fire")
        {
            if (invincibility == false)
            {
                Debug.Log("Hp" + hp);
                firefx.Play();
                isBurn = true;
                invincibility = true;
                monsterColor.material.color = Color.white;
                hp -= player.GetComponent<BasePlayer>().fireDamage;
                Invoke("InvincibilityClear", invincibilityTime);
                Invoke("BurnEffect", BurnTime);
            }
        }

        if (other.gameObject.tag == "Axe")
        {
            if (invincibility == false)
            {
                Debug.Log("Hp" + hp);
                invincibility = true;
                monsterColor.material.color = Color.white;
                hp -= player.GetComponent<BasePlayer>().axeDamage;
                Invoke("InvincibilityClear", invincibilityTime);

            }
        }
    }

    public virtual void HitExplosion(Vector3 explosionPos)
    {
        if (invincibility == false)
        {
            Debug.Log("FireBottleHit");
            firefx.Play();
            isBurn = true;
            invincibility = true;
            monsterColor.material.color = Color.white;
            hp -= player.GetComponent<BasePlayer>().fireDamage / 2;
            Invoke("InvincibilityClear", invincibilityTime);
            Invoke("BurnEffect", BurnTime);
        }
    }

    protected virtual void BurnEffect()
    {
        firefx.Stop();
        isBurn = false;
    }
    public void OnhitDamage()
    {
        if (invincibility == false)
        {
            Debug.Log("Hp" + hp);
            firefx.Play();
            isBurn = true;
            invincibility = true;
            monsterColor.material.color = Color.white;
            hp -= player.GetComponent<BasePlayer>().fireDamage;
            Invoke("InvincibilityClear", invincibilityTime);
            Invoke("BurnEffect", 5f);
        }
    }

    private void OnParticleTrigger()
    {
        
    }

    protected virtual void OnTriggerExit(Collider other)
    {

    }
}
