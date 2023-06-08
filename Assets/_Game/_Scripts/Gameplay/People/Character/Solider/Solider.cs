using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoliderType
{
    none,
    Troop,
    Demotinolis,
    MaskMan,
    Bazoka,
    Technician,
    FalmethTower
}
public class Solider : ABCharacter
{
    protected float timerRate;
    protected int damage;
    protected float fireRate;
    protected float ranger;
    public float levelFireRate;
    public float levelRanger;
    public int levelDamage;
    public int levelSolider;
    public int starSolider;
    public SoliderType soliderType;


    private void Start()
    {
        GetData();
        OnInit();
    }
    private void Update()
    {
        if (!GameManager.Instance.IsState(GameState.Gameplay) || GameManager.Instance.IsState(GameState.FinishGame)) return;

        OnUpdate();
    }
    public void GetData()
    {

        for (int i = 0; i < ResourcesManager.Instance.dataSolider.soliderInfors.Count; i++)
        {
            SoliderInfor soliderInfor = ResourcesManager.Instance.dataSolider.soliderInfors[i];
            if (soliderInfor.soliderType == soliderType && levelSolider == soliderInfor.levelSoliderDT)
            {
                levelDamage = soliderInfor.damageSoliderDT;
                levelFireRate = soliderInfor.fireRateSoliderDT;
                levelRanger = soliderInfor.rangerSoliderDT;
                break;
            }
        }
    }
    public void OnInit()
    {
        timerRate = 0;
        fireRate = 3;
        fireRate = fireRate - levelFireRate / 2;
        damage = levelDamage * 3;
        ranger = levelRanger * 5 + 10;
    }
    public void OnUpdate()
    {
        CheckAndAttack();
    }
    public override void Atack()
    {
        Enemy enemy = Plane.Instance.GetEnemy();
        if (enemy == null) return;
        if (enemy.isDie) return;
        if (enemy.DistanceToLose() > ranger) return;
        GameObject go = ObjectPooling.Instance.GetGameObject(weaponType, weaponPoints.position);
        Weapon weapon = go.GetComponent<Weapon>();
        weapon.tF.LookAt(enemy.tF.position - tF.position);
        weapon.damage = damage;
        weapon.Direction(enemy.tF.position);
    }

    public override void CheckAndAttack()
    {
        timerRate += Time.deltaTime;
        if (timerRate >= fireRate)
        {
            Atack();
            timerRate = 0;
        }
    }

}
