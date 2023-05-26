using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{

    public LoseZone loseZone;
    public static float coints;

    private void Awake()
    {
        
    }
    void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnAwake()
    {

    }
    public void OnInit()
    {
        loseZone.OnWinGame += LoseGame;
    }

    public void AddScore(float coint)
    {
        coints += coint;
    }
    public void WinGame()
    {
        Debug.Log("Win");
    }
    public void LoseGame()
    {
        Debug.Log("LoseGame");
    }
    public void GetLoseZone(LoseZone loseZone)
    {
        this.loseZone = loseZone;
    }
}
