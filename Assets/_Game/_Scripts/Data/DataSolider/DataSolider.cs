using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="DataSolider",menuName = "Data/DataSolider", order =1)]
public class DataSolider : ScriptableObject
{
    public List<SoliderInfor> soliderInfors = new List<SoliderInfor>();
}
[System.Serializable]
public class SoliderInfor
{
    public int damageSoliderDT;
    public float rangerSoliderDT;
    public float fireRateSoliderDT;
    public int starSoliderDT;
    public int levelSoliderDT;
    public SoliderType soliderType;
}
