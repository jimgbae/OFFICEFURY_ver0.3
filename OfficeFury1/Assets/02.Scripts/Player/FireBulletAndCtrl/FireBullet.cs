using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    //�ڱ� �ڽ��� ����ִ¿뵵 �����ð������� �����ؾߵ˴ϴ�.
    public GameObject My;
    GameObject player;

    //ȭ�����󰡴� �ӵ�
    public float speed = 5.0f;
    public float fireUpSize_X = 1.0f;
    public float fireUpSize_Y = 1.0f;
    public float fireUpSize_Z = 1.0f;

    //public float fireDestroy = 5.0f;

    private Transform tr;
    //�Ѿ� ���� ũ��


    protected Vector3 destination;
    float distance;
    public float detect;

    void Awake()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        player = GameObject.FindGameObjectWithTag("Player");

        tr = GetComponent<Transform>();

        //Invoke("FireDelete", fireDestroy);

    }


    void Update()
    {
        distance = Vector3.Distance(player.transform.position, My.transform.position);
        if (distance >= detect)
        {
            FireDelete();
        }

        //���� Ŀ���� ȭ��
        tr.localScale = new Vector3(tr.localScale.x + Time.deltaTime * fireUpSize_X, tr.localScale.y + Time.deltaTime * fireUpSize_Y, tr.localScale.z + Time.deltaTime * fireUpSize_Z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor") {
            FireDelete();
        }
    }

    void FireDelete() {
        Destroy(My);
    }
}

