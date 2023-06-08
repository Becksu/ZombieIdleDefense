using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseZone : MonoBehaviour
{
    public delegate void LoseGameEvent();
    public event LoseGameEvent OnLoseGame;
    private void Awake()
    {
        LevelManager.Instance.GetLoseZone(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constans.TAG_ENEMY))
        {
            OnLoseGame?.Invoke();
        }
    }

}
