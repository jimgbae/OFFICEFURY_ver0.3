using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Character : MonoBehaviour
{

    public float hp;
    public float speed;

    public bool invincibility = false;
    public float invincibilityTime = 0.5f;

    protected virtual void InvincibilityClear()   //무적해제
    {
        invincibility = false;
    }
}
