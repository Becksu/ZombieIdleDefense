using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public delegate void WinGame();
    public event WinGame OnWinGame;
    public Transform tF;
    public NavMeshAgent agentMeshEnemy;
    public ParticleSystem vfxHeath;
    public LayerMask layerLoseZone;
    public float Hp;
    public float speed;
    public float price;
    public bool isDie => Hp <= 0;
    private void Awake()
    {
        OnAwake();
    }

    void Update()
    {
        OnUpdate();
    }
    protected virtual void OnAwake()
    {
        tF = transform;
        agentMeshEnemy = GetComponent<NavMeshAgent>();
        Transform go = transform.Find("VFX_Heath");
        vfxHeath = go.GetComponent<ParticleSystem>();
    }
    public virtual void OnInit()
    {
        Hp = 100 + DataManager.Instance.waveGameDT;
        speed = 1;
        agentMeshEnemy.speed = speed + DataManager.Instance.waveGameDT / 4;
        price = DataManager.Instance.waveGameDT * 500;
        Collider collider = GetComponent<Collider>();
        collider.enabled = true;
    }
    protected virtual void OnUpdate()
    {
        if(isDie) StopMove();
        else
        {
            Move();
        }
    }
    public float DistanceToLose()
    {
        RaycastHit hit;
        float distance = 0;

        if (Physics.Raycast(tF.position, Vector3.forward * 2f, out hit, 40f, layerLoseZone))
        {
            Vector3 targetLoseZone = Vector3.Scale(hit.collider.transform.position, Vector3.forward);
            Vector3 posCurren = Vector3.Scale(tF.position, Vector3.forward);
            distance = Vector3.Distance(posCurren, targetLoseZone);

            return distance;
        }
        return 0;
    }
    protected void Damage(float damage)
    {
        if (!isDie)
        {
            Hp -= damage;
            if (isDie)
            {
                EnemyDie();
                Invoke(nameof(EnemyReturn), 2f);
            }
        }
    }
    public void EnemyDie()
    {
        vfxHeath.Play();
        CointManager.Instance.EventCoint(price);
        Collider collider = GetComponent<Collider>();
        collider.enabled = false;
        Level.Instance.enemyCounts--;
        Level.Instance.enemys.Remove(this);
        if (Level.Instance.enemyCounts > 0) return;
        OnWinGame?.Invoke();
    }
    public void EnemyReturn()
    {
        gameObject.SetActive(false);
    }
    public void Move()
    {
        agentMeshEnemy.isStopped = false;
        Vector3 target = tF.position + DistanceToLose() * Vector3.forward;
        agentMeshEnemy.SetDestination(target);
    }
    public void StopMove()
    {
        agentMeshEnemy.isStopped = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constans.TAG_WEAPON))
        {
            Weapon weapon = other.GetComponent<Weapon>();
            Damage(weapon.damage);
        }
    }
}
