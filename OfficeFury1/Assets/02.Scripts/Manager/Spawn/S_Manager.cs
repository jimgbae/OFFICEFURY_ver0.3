using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class S_Manager : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPoints; // ���� ����Ʈ���� �迭
    [SerializeField]
    private Camera mainCamera; // ���� ī�޶�

    public static int MaxMonsterCount = 0;
    public static int GameMonsterCount = 0; // �������� �������� �׻� 0���� �ʱ�ȭ �����ֱ�
    public static float spawnInterval = 8f;
    public static List<MonsterData> monsterDataList;
    public List<MonsterData> monsterdata;

    #region ���� Ȯ�� �� ���� ����
    //Ȯ��
    public static int m_paper = 0;
    public static int m_box = 0;
    public static int m_comp = 0;
    public static int m_fly = 0;
    public static int m_long = 0;
    public static int m_elite = 0;
    public static int m_safe = 0;

    //ī��Ʈ
    public static int m_boxCount = 0;
    public static int m_compCount = 0;
    public static int m_safeCount = 0;
    public static int m_flyCount = 0;
    public static int m_eliteCount = 0;
    public static int m_longCount = 0;

    //�ƽ�ī��Ʈ
    public static int m_boxMaxCount = 0;
    public static int m_compMaxCount = 1;
    public static int m_safeMaxCount = 1;
    public static int m_flyMaxCount = 0;
    public static int m_eliteMaxCount = 0;
    public static int m_longMaxCount = 0;
    #endregion

    #region ���� ī��Ʈ
    public static MonsterData GetMonsterData()
    {
        if (m_safe != 0 && m_safeCount < m_safeMaxCount && GetThisChanceResult_Percentage(m_safe))
        {
            m_safeCount++;
            return monsterDataList[4]; //6
        }
        else if (m_elite != 0 && m_eliteCount < m_eliteMaxCount && GetThisChanceResult_Percentage(m_elite))
        {
            m_eliteCount++;
            return monsterDataList[5]; // 5
        }
        else if (m_long != 0 && m_longCount < m_longMaxCount && GetThisChanceResult_Percentage(m_long))
        {
            m_longCount++;
            return monsterDataList[4]; //4
        }
        else if (m_fly != 0 && m_flyCount < m_flyMaxCount && GetThisChanceResult_Percentage(m_fly))
        {
            return monsterDataList[3]; //3
        }
        else if (m_comp != 0 && m_compCount < m_compMaxCount && GetThisChanceResult_Percentage(m_comp))
        {
            return monsterDataList[2]; //2
        }
        else if (m_box != 0 && m_boxCount < m_boxMaxCount && GetThisChanceResult_Percentage(m_box))
        {
            return monsterDataList[1]; //1
        }
        else
        {
            return monsterDataList[0];
        }
    }
    public static bool GetThisChanceResult_Percentage(float Percentage_Chance)
    {
        if (Percentage_Chance < 0.01f)
        {
            Percentage_Chance = 0.01f;
        }

        Percentage_Chance = Percentage_Chance / 100;

        bool Success = false;
        int RandAccuracy = 100;
        float RandHitRange = Percentage_Chance * RandAccuracy;
        int Rand = UnityEngine.Random.Range(1, RandAccuracy + 1);
        if (Rand <= RandHitRange)
        {
            Success = true;
        }
        return Success;
    } 

    #endregion

    void SetUp()
    {
        MaxMonsterCount = 1000;
        m_paper = 100;
        m_box = 0;
        m_comp = 0;
        m_fly = 0;
        m_long = 0;
        m_elite = 0;
        m_safe = 0;
    }

    void Start()
    {
        SetUp();
        SetSpawnPoint();
        SetMonster();
    }

    void Update()
    {
        CheckSpawnPointinCamera();
    }

    void SetMonster()
    {
        monsterDataList = new List<MonsterData>();

        //��ũ���ͺ� ������Ʈ�� ����Ϸ��� Resources ������ ����Ǿ� �־�� �մϴ�.
        MonsterData[] monsterDatas = Resources.LoadAll<MonsterData>("MonsterData");
        monsterDataList.AddRange(monsterDatas);
        monsterdata.AddRange(monsterDatas);
    }

    #region ���� ���� ����Ʈ
    void SetSpawnPoint()
    {
        Transform[] allspawnPoints = GetComponentsInChildren<Transform>(); //��������Ʈ�� ��� Transform ��������
        spawnPoints = new Transform[allspawnPoints.Length - 1]; //-1�� �θ� ����

        int index = 0;
        foreach (Transform child in allspawnPoints) //foreach������ transform �迭�� �� �ֱ�
        {
            if (child != transform)
            {
                spawnPoints[index] = child;
                index++;
            }
        }
    }

    void CheckSpawnPointinCamera() //������Ʈ�� ���ؼ� ����Ʈ�� ���� ����Ʈ�� �ִ��� ��� Ȯ��
    {
        Camera camera = mainCamera.GetComponent<Camera>(); //ī�޶� ���� ��������

        foreach (Transform spawnPoint in spawnPoints)
        {
            // ���� ����Ʈ�� ���� ��ǥ�� ����Ʈ ��ǥ�� ��ȯ
            Vector3 viewportPoint = camera.WorldToViewportPoint(spawnPoint.position);

            // ����Ʈ ��ǥ�� ī�޶� �þ� �ȿ� �ִ��� Ȯ��
            if (viewportPoint.x >= 0 && viewportPoint.x <= 1 && viewportPoint.y >= 0 && viewportPoint.y <= 1 && viewportPoint.z > 0)
            {
                spawnPoint.gameObject.SetActive(false); //�� ��Ʈ�� ������ Active ��������
            }
            else
                spawnPoint.gameObject.SetActive(true);
        }
    }
    #endregion
}
