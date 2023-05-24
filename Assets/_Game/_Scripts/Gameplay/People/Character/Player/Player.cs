using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ABCharacter
{
    public int bulletCap;
    public int damage;
    public float reload;
    public PoolType poolType;
    public Transform weaponPoints;
    public Enemy target;

    private void Awake()
    {
        OnAwake();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }
    public void OnAwake()
    {
        tF = transform;
        weaponPoints = transform.Find("WeaponPoints");
    }
    public void OnInit()
    {
        //bulletCap,reload,damage from data

    }
    public void OnUpdate()
    {
        CheckAndAttack();
    }



    public override void Atack()
    {
        Enemy enemy = Plane.Instance.GetEnemy();
        if (enemy == null) return;
        if (enemy.DistanceToLose() > 10 && enemy.isDie) return;
        GameObject go = ObjectPooling.Instance.GetGameObject(poolType, weaponPoints.position);
        Weapon weapon = go.GetComponent<Weapon>();
        weapon.tF.LookAt(enemy.tF.position - tF.position);
        weapon.damage = damage;
        weapon.Direction(enemy.tF.position);
        bulletCap--;
    }
    public void CheckAndAttack()
    {
        if (Input.GetMouseButtonDown(0) && bulletCap >= 1)
        {
            Atack();
            if (bulletCap == 0)
            {
                Invoke(nameof(Reload), reload);
            }
        }
    }
    public void Reload()
    {
        //bulletCap from data
        bulletCap = 10;
    }

}
