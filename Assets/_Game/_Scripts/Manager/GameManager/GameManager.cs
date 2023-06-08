using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Menu,
    Gameplay,
    Units,
    Shop,
    Upgrades,
    BaseCamp,
    FinishGame
}
public class GameManager : Singleton<GameManager>
{

    protected GameState gameState;
    public void ChangStateGame(GameState state)
    {
        gameState = state;
    }

    public bool IsState(GameState state)
    {
        return gameState == state;
    }
}
