using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CointManager : Singleton<CointManager>
{
    public delegate void AddScore(float a);
    public event AddScore AddScoreWave;
    public float coint;
    void Start()
    {

        AddScoreWave += CointWave;
    }

    public void RegisnEvent()
    {
        AddScoreWave += CointWave;
    }
    public void CointWave(float coins)
    {
        this.coint += coins;
    }
}
