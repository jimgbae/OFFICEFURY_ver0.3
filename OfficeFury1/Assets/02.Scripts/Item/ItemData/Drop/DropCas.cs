using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCas : BaseDropItem
{
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
        player.GetComponent<BasePlayer>().activeGauge = player.GetComponent<BasePlayer>().maxActiveGauge;
        base.OnCollisionEnter(collision);

    }

}
