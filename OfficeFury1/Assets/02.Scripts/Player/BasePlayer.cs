using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODPlus;
using FMODUnity;
using System.Diagnostics.Tracing;

public class BasePlayer : MonoBehaviour
{
    GameObject player;
    GameObject monster;
    public FMODAudioSource[] sound;

    bool isDead = true;

    public ParticleSystem Heal;

    public float hp=3;
    public float fireDamage;
    public float cocktailDamage;
    public float axeDamage;
    public float activeGauge;

    public float maxActiveGauge = 100;

    public float coin = 0;

    public bool invincibility = false;
    public float invincibilityTime = 0.5f;

    void Awake()
    {
        
    }

    void Start()
    {
       
    }

    void  Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            if (invincibility == false)
            {
                sound[1].Play();
                invincibility = true;
                hp--;
                Invoke("invincibilityClear", invincibilityTime);
            }
        }

    }

    void invincibilityClear() {
        invincibility = false;
    }

    public void HealEff() {
        Heal.Play();
    }

    public void Deadsound()
    {
        if (isDead)
            sound[0].Play();
        isDead = false;
    }
}
