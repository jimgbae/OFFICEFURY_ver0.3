using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    public GameObject firebottle;
    public GameObject Axe; //ȸ������ �ִϸ��̼����� ó���� ���� R�� ���� �ݶ��̴� ���� 4�ʰ�

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
