using FMOD;
using FMODPlus;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DropCoffe : BaseDropItem
{
    [SerializeField] FMODAudioSource sound;

    public int plusHP = 1;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        sound.Play();
        player.GetComponent<BasePlayer>().hp = player.GetComponent<BasePlayer>().hp + plusHP;
        player.GetComponent<BasePlayer>().HealEff();
        base.OnCollisionEnter(collision);
        
    }
}
