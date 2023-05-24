using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float damage;
    public Transform tF;
    public PoolType poolType;
    protected Vector3 direction;

    private void Awake()
    {
        tF = transform;
    }
    void Start()
    {
        OnInit();
    }

    void Update()
    {
        OnUpdate();
    }
    public virtual void OnInit()
    {
        rb = GetComponent<Rigidbody>();
    }
    public virtual void OnUpdate()
    {
        Move();
    }
    public virtual void Move()
    {
        Invoke(nameof(IsTouch), 2f);
    }
    public virtual void IsTouch()
    {
        ObjectPooling.Instance.ReturnGameObject(poolType, gameObject);
    }
    public void Direction(Vector3 dir)
    {
        direction = dir;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constans.TAG_ENEMY))
        {
            IsTouch();
        }
    }

}
