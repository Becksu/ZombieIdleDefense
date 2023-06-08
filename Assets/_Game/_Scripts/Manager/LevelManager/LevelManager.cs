using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{

    public LoseZone loseZone;
    public Level level;
    public Player player;
    public int levelCurrent;
    public float coints;
    private float currentWave;

    void Start()
    {
        OnInit();
    }

    public void OnAwake()
    {

    }
    public void OnInit()
    {
        coints = DataManager.Instance.coints;
        loseZone.OnLoseGame += LoseGame;
        UIManager.menuUI.gamePlayerEvent += GamePlayStart;
        currentWave = DataManager.Instance.waveGameDT;
    }

    public void AddScore(float coint)
    {
        coints += coint;
    }
    public void WinGame()
    {
        GameManager.Instance.ChangStateGame(GameState.FinishGame);
        currentWave++;
        DataManager.Instance.waveGameDT = currentWave;
        UIManager.Instance.OpenWinGame();
        NextLevel();
        Debug.Log("Win");
    }
    public void LoseGame()
    {
        GameManager.Instance.ChangStateGame(GameState.FinishGame);
        UIManager.Instance.OpenLoseGame();
        
        Debug.Log("LoseGame");
    }
    public void GamePlayStart()
    {
        GameManager.Instance.ChangStateGame(GameState.Gameplay);
        if (level != null) 
        {
            level.DespawnLevel();
        }
        GameObject go = Resources.Load<GameObject>("Level/Level");
        level = Instantiate(go).GetComponent<Level>();
        level.level = levelCurrent;
        level.OnInit();
       // Camera.Instance.GameplayCamera(0f, 5f);
    }
    public void GetLoseZone(LoseZone loseZone)
    {
        this.loseZone = loseZone;
    }

    public void NextLevel()
    {
        levelCurrent++;
    }
}
