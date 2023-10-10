using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    public GameObject firebottle;
    public GameObject Axe; //회전도끼 애니메이션으로 처리할 예정 R누 르면 콜라이더 켜짐 4초간

    private float SpinTime_max = 4f;
    private float SpinTime_cur = 0f;
    private bool b_SpinCheck = false;

    public Transform playerEquipPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SpinAxe()
    {
        Debug.Log(SpinTime_cur);
        if (SpinTime_cur < SpinTime_max)
        {
            Axe.GetComponent<SphereCollider>().enabled = true;

        }
        else
        { 
            SpinTime_cur = 0f;
            Axe.GetComponent<SphereCollider>().enabled = false;
        }
    }
}
