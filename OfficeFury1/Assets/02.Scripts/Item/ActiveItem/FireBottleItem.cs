using FMODPlus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FireBottleItem : MonoBehaviour
{
    [SerializeField] float BotSize = 2f;
    [SerializeField] float time = 5f;
    [SerializeField] float curtime = 0;
    [SerializeField] bool brokebtl = false;
    [SerializeField] ParticleSystem trail;
    [SerializeField] ParticleSystem Boom;
    [SerializeField] GameObject Fire;
    [SerializeField] FMODAudioSource BoomSound;
    [SerializeField] Vector3 Area;


    Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.AddTorque(transform.up*5,ForceMode.Force);
        rigid.AddTorque(transform.right * 5, ForceMode.Force);

        trail.Play();
        Area = new Vector3(2f, 0, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        


        if (brokebtl)
        {
            curtime += Time.deltaTime;
            if(curtime < time) { }
            {
                RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, BotSize, Vector3.up, 0, LayerMask.GetMask("Monster"));
                foreach (RaycastHit hitObj in rayHits)
                {
                    hitObj.transform.GetComponent<BaseMonster>().HitExplosion(transform.position);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "ActiveFloor")
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            Area.y = this.gameObject.transform.position.y;
            BoomSound.Play();
            Boom.Play();
            trail.Stop();
            RandomFire();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            brokebtl = true;
            Destroy(this.gameObject, time);
        }
    }

    private void RandomFire()
    {
        
        for (int i = 0; i < 10; i++)
        {
            Vector2 randomCirclePoint = Random.insideUnitCircle * BotSize;

            // ���� ��ġ�� �����մϴ�. Y ���� 0���� �����մϴ�.
            Vector3 spawnPosition = new Vector3(
                transform.position.x + randomCirclePoint.x,
                0f,
                transform.position.z + randomCirclePoint.y
            );

            Debug.Log(spawnPosition);
            Destroy(Instantiate(Fire, spawnPosition, Quaternion.identity), 5f);
        }
    }
}
