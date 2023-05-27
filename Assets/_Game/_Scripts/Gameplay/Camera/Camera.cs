using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : Singleton<Camera>
{
    public Transform posMenu;
    public Transform posGameplay;
    public Vector3 offset;
    public float speed;

    private void Start()
    {
        OnInit();
    }
    
    private void LateUpdate()
    {
        if (!GameManager.Instance.IsState(GameState.Gameplay)) return;
        GamePlayCamera();
    }
    public void OnInit()
    {
        transform.position = posMenu.position;
        transform.rotation = posMenu.rotation;
    }
    //public void GameplayCamera(float time,float timer)
    //{
    //    if (time < timer)
    //    {
    //        time += Time.deltaTime;
    //        transform.position = Vector3.Lerp(transform.position, posGameplay.position, timer * Time.deltaTime);
    //        transform.rotation = Quaternion.Lerp(transform.rotation, posGameplay.rotation, timer * Time.deltaTime);
    //        Debug.Log("asfd");
    //        if (time < timer) { GameplayCamera(time,timer);}
    //    }
    //}
    public void GamePlayCamera()
    {
        if (Vector3.Distance(transform.position, posGameplay.position) <= 0.01f) return;
        transform.position = Vector3.Lerp(transform.position, posGameplay.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, posGameplay.rotation, speed * Time.deltaTime);
    }
}
