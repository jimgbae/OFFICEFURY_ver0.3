using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class S_Manager : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPoints; // 스폰 포인트들의 배열
    [SerializeField]
    private Camera mainCamera; // 메인 카메라

    public static int MaxMonsterCount = 0;
    public static int GameMonsterCount = 0; // 스테이지 마무리시 항상 0으로 초기화 시켜주기
    public static float spawnInterval = 8f;
    public static List<MonsterData> monsterDataList;
    public List<MonsterData> monsterdata;

    #region 몬스터 확률 및 제한 변수
    //확률
    public static int m_paper = 0;
    public static int m_box = 0;
    public static int m_comp = 0;
    public static int m_fly = 0;
    public static int m_long = 0;
    public static int m_elite = 0;
    public static int m_safe = 0;

    //카운트
    public static int m_boxCount = 0;
    public static int m_compCount = 0;
    public static int m_safeCount = 0;
    public static int m_flyCount = 0;
    public static int m_eliteCount = 0;
    public static int m_longCount = 0;

    //맥스카운트
    public static int m_boxMaxCount = 0;
    public static int m_compMaxCount = 1;
    public static int m_safeMaxCount = 1;
    public static int m_flyMaxCount = 0;
    public static int m_eliteMaxCount = 0;
    public static int m_longMaxCount = 0;
    #endregion

    #region 몬스터 카운트
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

        //스크립터블 오브젝트를 사용하려면 Resources 폴더에 저장되어 있어야 합니다.
        MonsterData[] monsterDatas = Resources.LoadAll<MonsterData>("MonsterData");
        monsterDataList.AddRange(monsterDatas);
        monsterdata.AddRange(monsterDatas);
    }

    #region 몬스터 스폰 포인트
    void SetSpawnPoint()
    {
        Transform[] allspawnPoints = GetComponentsInChildren<Transform>(); //스폰포인트의 모든 Transform 가져오기
        spawnPoints = new Transform[allspawnPoints.Length - 1]; //-1로 부모 제외

        int index = 0;
        foreach (Transform child in allspawnPoints) //foreach문으로 transform 배열에 값 넣기
        {
            if (child != transform)
            {
                spawnPoints[index] = child;
                index++;
            }
        }
    }

    void CheckSpawnPointinCamera() //업데이트를 통해서 뷰포트에 스폰 포인트가 있는지 계속 확인
    {
        Camera camera = mainCamera.GetComponent<Camera>(); //카메라 정보 가져오기

        foreach (Transform spawnPoint in spawnPoints)
        {
            // 스폰 포인트의 월드 좌표를 뷰포트 좌표로 변환
            Vector3 viewportPoint = camera.WorldToViewportPoint(spawnPoint.position);

            // 뷰포트 좌표가 카메라 시야 안에 있는지 확인
            if (viewportPoint.x >= 0 && viewportPoint.x <= 1 && viewportPoint.y >= 0 && viewportPoint.y <= 1 && viewportPoint.z > 0)
            {
                spawnPoint.gameObject.SetActive(false); //뷰 포트에 들어오면 Active 꺼버리기
            }
            else
                spawnPoint.gameObject.SetActive(true);
        }
    }
    #endregion
}
