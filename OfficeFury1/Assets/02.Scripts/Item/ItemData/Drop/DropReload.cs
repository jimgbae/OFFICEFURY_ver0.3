using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropReload : BaseDropItem
{

    const float seconds = 60;

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
        player.GetComponent<FireCtrl>().gasGauge = player.GetComponent<FireCtrl>().maxGasGauge * seconds;
        base.OnCollisionEnter(collision);

    }


}
