using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ABCharacter : MonoBehaviour
{
    public Transform tF;
    private void Awake()
    {
        tF = transform;
    }
    public abstract void Atack();
}
