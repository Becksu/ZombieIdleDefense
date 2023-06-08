using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class WinGame : FinishGame
{
    public override void CloseFinishGame()
    {
        UIManager.winGameUI.gameObject.SetActive(false);
    }
}
