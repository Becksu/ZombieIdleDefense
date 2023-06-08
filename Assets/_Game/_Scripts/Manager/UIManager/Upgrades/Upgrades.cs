using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class Upgrades : MonoBehaviour
{
    public Button bntsBack;

    public Button[] bntsUplevel;

    private void Start()
    {

        Action[] actions = new Action[]
        {
            LevelUpDamage,
            LevelUpReload,
            LevelUpBulletCap
        };

        for (int i = 0; i < bntsUplevel.Length; i++)
        {
            int index = i;
            bntsUplevel[index].onClick.AddListener(() =>
            {
                actions[index]?.Invoke();
            });
        }

        bntsBack.onClick.AddListener(CloseUpgrades);
    }
    public void CloseUpgrades()
    {
        GameManager.Instance.ChangStateGame(GameState.Menu);
        UIManager.upgradeUI.gameObject.SetActive(false);
        UIManager.Instance.OpenMenuUI();
        LevelManager.Instance.player.OnInit();
    }
    public void LevelUpDamage()
    {
         
        DataManager.Instance.damagePlayerDT++;
    }
    public void LevelUpReload()
    {
        DataManager.Instance.reloadPlayerDT += .25f;
    }
    public void LevelUpBulletCap()
    {
        DataManager.Instance.bulletCapPlayerDT++;
    }
}
