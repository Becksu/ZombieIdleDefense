using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class FinishGame : MonoBehaviour
{
    public Button[] bnts = new Button[2];
    private void Start()
    {
        Action<int> actions = Claim;

        for (int i = 0; i < bnts.Length; i++)
        {
            int index = i;
            bnts[index].onClick.AddListener(() =>
            {
                actions?.Invoke(index + 1);
            });
        }
    }

    public void Claim(int a)
    {
        Debug.Log("menu");
        LevelManager.Instance.coints += CointManager.Instance.coint * a;
        DataManager.Instance.coints = LevelManager.Instance.coints;
        CointManager.Instance.coint = 0;
        CloseFinishGame();
        UIManager.Instance.OpenMenuUI();
        Camera.Instance.OnInit();
        LevelManager.Instance.level.DespawnLevel();
    }
    public virtual void CloseFinishGame()
    {
        
    }
}
