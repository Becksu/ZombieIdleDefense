using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CointManager : Singleton<CointManager>
{
    public delegate void AddScore(float t);
    public event AddScore AddScoreWave;
    public float coint;
    void Start()
    {
        AddScoreWave += AddCoint;
    }
    public void EventCoint(float a)
    {
        AddScoreWave?.Invoke(a);
    }
    public void AddCoint(float coint)
    {
        this.coint += coint;
    }
}
