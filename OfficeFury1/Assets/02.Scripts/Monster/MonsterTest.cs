using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class MonsterTest : MonoBehaviour
{
    private Transform player;  // �÷��̾��� Transform
    private NavMeshAgent agent;  // NavMesh ������Ʈ

    public float damage = 10f;
    public float speed = 1.0f;
    public float hp = 100f;

    public void Setup(float newHp, float newDamage, float newSpeed)
    {
        hp = newHp;
        damage = newDamage;
        agent.speed = newSpeed;
        //�ؽ�ó�� ���׸����� �����ͼ� �ٲ� �� ����.
    }

    private void Awake()
    {
        // �÷��̾��� Transform ã�� (�÷��̾� ������Ʈ�� �±׸� "Player"�� �����ؾ� ��)
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();// NavMesh ������Ʈ ����
    }

    void Start()
    {

        if (agent != null)
        {
            if (player != null)
            {
                // NavMeshAgent�� ������ ����
                agent.SetDestination(player.position);
            }
            else
            {
                Debug.LogError("��ǥ ��ġ (target)�� �������� �ʾҽ��ϴ�.");
            }
        }
        else
        {
            Debug.LogError("NavMeshAgent�� �� ��ü�� �߰����� �ʾҰų� ��Ȱ��ȭ�Ǿ� �ֽ��ϴ�.");
        }
    }

    void Update()
    {
        // �÷��̾ ��� ����
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }
}
