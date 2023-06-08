using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="DataEnemyInLevel",menuName = "Data/DataEnemyInLevel")]
public class DataEnemyLevel : ScriptableObject
{
    public List<LevelInfo> levelInfo;
}

[System.Serializable]

public class LevelInfo
{
    public PoolType[] poolType;
}