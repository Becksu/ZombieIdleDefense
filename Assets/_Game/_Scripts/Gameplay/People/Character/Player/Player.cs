using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ABCharacter
{
    public int bulletCap;
    public int damage;
    public float reload;
    public float ranger;

    public int maxDamage;
    public int maxReload;
    public int maxBulletCap;

    void Start()
    {
        OnInit();
        reload = 3;
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }

    public void OnInit()
    {
        reload = 3;
        bulletCap = DataManager.Instance.bulletCapPlayerDT;
        damage = DataManager.Instance.damagePlayerDT;
        reload -= DataManager.Instance.reloadPlayerDT;
    }
    public void OnUpdate()
    {
        if (!GameManager.Instance.IsState(GameState.Gameplay)||GameManager.Instance.IsState(GameState.FinishGame)) return;
        CheckAndAttack();
    }

    public override void Atack()
    {
        Enemy enemy = Plane.Instance.GetEnemy();
        if (enemy == null) return;
        if (enemy.DistanceToLose() >= ranger && enemy.isDie) return;
        GameObject go = ObjectPooling.Instance.GetGameObject(weaponType, weaponPoints.position);
        Weapon weapon = go.GetComponent<Weapon>();
        weapon.tF.LookAt(enemy.tF.position - tF.position);
        weapon.damage = damage;
        weapon.Direction(enemy.tF.position);
        bulletCap--;
    }
    public override void CheckAndAttack()
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
