using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public static Menu menuUI;
    public static Gameplay gameplayUI;
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
            menuUI = Instantiate(go, transform).GetComponent<Menu>();
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
}
