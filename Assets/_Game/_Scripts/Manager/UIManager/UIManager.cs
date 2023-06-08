using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public static Menu menuUI;
    public static Gameplay gameplayUI;
    public static WinGame winGameUI;
    public static LoseGame loseGameUI;
    public static Upgrades upgradeUI;
    public Transform tf;
    private void Awake()
    {
        tf = transform;
    }
    void Start()
    {
        OpenMenuUI();
    }
    public void OpenMenuUI()
    {
        if (menuUI == null)
        {
            GameObject go = Resources.Load<GameObject>("UI/Canvas-Menu");
            menuUI = Instantiate(go, tf).GetComponent<Menu>();
        }
        else
        {
            menuUI.gameObject.SetActive(true);
        }
        GameManager.Instance.ChangStateGame(GameState.Menu);
    }
    public void CloseMenuUi()
    {
        menuUI.gameObject.SetActive(false);
    }
    public void OpenWinGame()
    {
        if (winGameUI == null)
        {
            GameObject go = Resources.Load<GameObject>("UI/Canvas-Win");
            winGameUI = Instantiate(go, tf).GetComponent<WinGame>();
        }
        else
        {
            winGameUI.gameObject.SetActive(true);
        }
        gameplayUI.gameObject.SetActive(false);
        menuUI.gameObject.SetActive(false); 
    }
    public void CloseWinGame()
    {
        winGameUI.gameObject.SetActive(false);
    }
    public void OpenLoseGame()
    {
        if (loseGameUI == null)
        {
            GameObject go = Resources.Load<GameObject>("UI/Canvas-Lose");
            loseGameUI = Instantiate(go, transform).GetComponent<LoseGame>();
        }
        else
        {
            loseGameUI.gameObject.SetActive(true);
        }
        menuUI.gameObject.SetActive(false); 
        gameplayUI.gameObject.SetActive(false);
    }
    public void CloseLoseGame()
    {
        loseGameUI.gameObject.SetActive(false);
    }
}
