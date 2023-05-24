using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public Transform tF;
    public NavMeshAgent agentMeshEnemy;
    public LayerMask layerLoseZone;
    public float Hp;
    public float speed;
    public float price;
    public bool isDie => Hp <= 0;
    protected CointManager cointManager;
    private void Awake()
    {
        OnAwake();
    }
    void Start()
    {
        OnInit();
    }

    void Update()
    {
        OnUpdate();
    }
    protected virtual void OnAwake()
    {
        tF = transform;
        agentMeshEnemy = GetComponent<NavMeshAgent>();
        cointManager = CointManager.Instance;

    }
    public virtual void OnInit()
    {
        Hp = 100;
        Collider collider = GetComponent<Collider>();
        collider.enabled = true;
        //sped from data
        //price from data
        //agentMeshEnemy.speed = speedf;
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

        if (Physics.Raycast(tF.position, Vector3.forward * 2f, out hit, 20f, layerLoseZone))
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
                //cointManager.AddScoreWave?.Invoke(price);
                Collider collider = GetComponent<Collider>();
                collider.enabled = false;
                Invoke(nameof(CharacterDie), 2f);
            }
        }
    }

    public void CharacterDie()
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
