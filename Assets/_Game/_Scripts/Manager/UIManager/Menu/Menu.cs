using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public delegate void GamePlayerEvent();
    public event GamePlayerEvent gamePlayerEvent;
    public Button bntsStart;
    public List<Action> actions = new List<Action>();
    public List<Button> buttons = new List<Button>();
    private void Start()
    {
        Action[] actionBnts = new Action[]
       {
            BntsStart,
            BntsRandomSolider,
            BntsUpgrades,
            BntsUnits,
            BntsCampBase,
            BntsDeathMode,
            BntsShop
       };
        for (int i = 0; i < actionBnts.Length; i++)
        {
            actions.Add(actionBnts[i]);
        }

        for(int i = 0; i < buttons.Count; i++)
        {
            int index = i;
            buttons[index].onClick.AddListener(() =>
            {
                actions[index].Invoke();
            });
        }
    }

    public void BntsStart()
    {
        
        if (UIManager.gameplayUI != null)
        {
            UIManager.gameplayUI.gameObject.SetActive(true);
        }
        else
        {
            GameObject go = Resources.Load<GameObject>("UI/Canvas-GamePlay");
            UIManager.gameplayUI = Instantiate(go, UIManager.Instance.tf).GetComponent<Gameplay>();
        }
        UIManager.Instance.CloseMenuUi();

        gamePlayerEvent?.Invoke();
    }
    public void BntsRandomSolider()
    {
        Debug.Log("BntsRandomSolider");
    }
    public void BntsUpgrades()
    {
        Debug.Log("BntsUpgrades");
        GameManager.Instance.ChangStateGame(GameState.Upgrades);
        UIManager.Instance.CloseMenuUi();
        if (UIManager.upgradeUI == null)
        {
            GameObject go = Resources.Load<GameObject>("UI/Canvas-Upgrades");
            UIManager.upgradeUI = Instantiate(go, UIManager.Instance.tf).GetComponent<Upgrades>();
        }
        else
        {
            UIManager.upgradeUI.gameObject.SetActive(true);
        }
    }
    public void BntsUnits()
    {
        Debug.Log("BntsUnits");

    }
    public void BntsCampBase()
    {
        Debug.Log("BntsCampBase");

    }
    public void BntsDeathMode()
    {
        Debug.Log("BntsDeathMode");

    }
    public void BntsShop()
    {
        Debug.Log("BntsShop");

    }
}
