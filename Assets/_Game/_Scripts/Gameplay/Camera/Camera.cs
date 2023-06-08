using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : Singleton<Camera>
{
    public Transform posMenu;
    public Transform posGameplay;
    public Transform posUpgrades;
    public Vector3 offset;
    public float speed;

    private void Start()
    {
        OnInit();
    }

    private void LateUpdate()
    {

        if (GameManager.Instance.IsState(GameState.Gameplay))
        {
            GamePlayCam();
        }
        else if (GameManager.Instance.IsState(GameState.Upgrades))
        {
            UpgradesCam();
        }
        else if (GameManager.Instance.IsState(GameState.Menu))
        {
            MenuCam();
        }
        else return;
    }
    public void OnInit()
    {
        transform.position = posMenu.position;
        transform.rotation = posMenu.rotation;
    }
    public void MenuCam()
    {
        if (Vector3.Distance(transform.position, posMenu.position) <= 0.1f) return;
        transform.position = Vector3.Lerp(transform.position, posMenu.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, posMenu.rotation, speed * Time.deltaTime);
    }
    public void GamePlayCam()
    {
        if (Vector3.Distance(transform.position, posGameplay.position) <= 0.01f) return;
        transform.position = Vector3.Lerp(transform.position, posGameplay.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, posGameplay.rotation, speed * Time.deltaTime);
    }
    public void UpgradesCam()
    {
        if (Vector3.Distance(transform.position, posUpgrades.position) <= 0.1f) return;
        transform.position = Vector3.Lerp(transform.position, posUpgrades.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, posUpgrades.rotation, speed * Time.deltaTime);
    }
}
