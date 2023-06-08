using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ABCharacter : MonoBehaviour
{
    public Transform tF;
    public PoolType weaponType;
    public Transform weaponPoints;


    private void Awake()
    {
        tF = transform;
        weaponPoints = transform.Find("WeaponPoints");
    }
    public abstract void Atack();
    public abstract void CheckAndAttack();
}
