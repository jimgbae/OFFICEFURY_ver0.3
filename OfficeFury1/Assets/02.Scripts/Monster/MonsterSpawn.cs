using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    private float nextSpawnTime;

    public GameObject monsterPrefab;
    public GameObject spawnObject;

    [SerializeField]private float TimeTick = 0f;
    [SerializeField] private float TimeCheck = 3f;
    //���� ���� ������Ʈ-> ��ġ ->�ֱ� ����
    //���� �Ŵ��� �����
    // Start is called before the first frame update
    void Start()
    {
        spawnObject = GameObject.Find("MonsterContainer");
    }

    // Update is called once per frame
    void Update()
    {
        TimeTick += Time.deltaTime;

        if (TimeTick > TimeCheck)
        {
            if (Time.time >= nextSpawnTime && S_Manager.MaxMonsterCount > S_Manager.GameMonsterCount)
            {
                SpawnMonster();
                nextSpawnTime = Time.time + S_Manager.spawnInterval; // ���� ���� �ð� ����
            }
        }
    }

    void SpawnMonster()
    {
        if(this.gameObject.activeSelf)
        {
            MonsterData randomdata = S_Manager.GetMonsterData();
            GameObject monster = Instantiate(randomdata.visualPrefab, this.transform.position, Quaternion.identity);
            monster.transform.parent = spawnObject.transform;
            S_Manager.GameMonsterCount++;
        }
    }
}
