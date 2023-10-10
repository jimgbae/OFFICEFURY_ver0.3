using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster_01", menuName = "GameData/Monster Data 01")]
public class MonsterData : ScriptableObject
{
    public string monsterName;
    public float hp;
    public float maxhp;
    public float damage;
    public float moveSpeed;
    public GameObject visualPrefab;
}

[CreateAssetMenu(fileName = "Monster_02", menuName = "GameData/Monster Data 02")]
public class MonsterData2 : ScriptableObject
{
    public string monsterName;
    public float hp;
    public float maxhp;
    public float damage;
    public float moveSpeed;
    public GameObject visualPrefab;
}
