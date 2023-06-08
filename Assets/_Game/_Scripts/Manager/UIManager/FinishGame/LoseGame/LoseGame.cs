using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGame : FinishGame
{
    public override void CloseFinishGame()
    {
        UIManager.loseGameUI.gameObject.SetActive(false);
    }
}
