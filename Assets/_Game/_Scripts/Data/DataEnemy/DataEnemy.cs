using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="DataEnemy",menuName = "Data/DataEnemy")]
public class DataEnemy : ScriptableObject
{
    public EnemyInfo[] enemyInfos; 
}
[System.Serializable]
public class EnemyInfo
{
    public float speed;
    public float hp;
    public float price;
    public EnemyType enemyType;
}
