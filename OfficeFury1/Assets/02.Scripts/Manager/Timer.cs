using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    //public Text timeText;
    public float time;
    public float MaxTime;
    public float SpawnTime;
    public int StageNum = 1;
    public bool Change = false;

    private void Awake()
    {
        MaxTime = time;
    }

    private void Update()
    {
        if (time > 0)
            time -= Time.deltaTime;
        SpawnTime += Time.deltaTime;
        if (StageNum == 1)
            StageTime_1();
    }


    private void StageTime_1() // 이거만 사용합니다 (1스테이지 시간당 확률조정)
    {
        if ((int)SpawnTime == 150)
        {
            S_Manager.m_paper = 80; //절대로 숫자만 건들이세요절대로 숫자만 건들이세요절대로 숫자만 건들이세요절대로 숫자만 건들이세요절대로 숫자만 건들이세요절대로 숫자만 건들이세요절대로 숫자만 건들이세요절대로 숫자만 건들이세요절대로 숫자만 건들이세요
            S_Manager.m_comp = 15;  //절대로 숫자만 건들이세요절대로 숫자만 건들이세요절대로 숫자만 건들이세요절대로 숫자만 건들이세요절대로 숫자만 건들이세요
            S_Manager.m_safe = 1;
            S_Manager.m_box = 1;
            S_Manager.m_fly = 3;
            S_Manager.m_flyMaxCount = 2;
            S_Manager.m_compMaxCount = 4;
        }
        else if ((int)SpawnTime == 120)
        {
            S_Manager.m_paper = 79;
            S_Manager.m_comp = 10;
            S_Manager.m_safe = 1;
            S_Manager.m_box = 10;
            S_Manager.m_compMaxCount = 3;
        }
        else if ((int)SpawnTime == 90)
        {
            S_Manager.m_paper = 89;
            S_Manager.m_comp = 5;
            S_Manager.m_safe = 1;
            S_Manager.m_box = 5;
            S_Manager.m_boxMaxCount = 2;
            S_Manager.m_compMaxCount = 2;
        }
        else if ((int)SpawnTime == 60)
        {
            S_Manager.m_paper = 94;
            S_Manager.m_comp = 5;
            S_Manager.m_safe = 1;
        }
        else if ((int)SpawnTime == 30)
        {
            S_Manager.m_paper = 99;
            S_Manager.m_safe = 1;
        }
    }

}
