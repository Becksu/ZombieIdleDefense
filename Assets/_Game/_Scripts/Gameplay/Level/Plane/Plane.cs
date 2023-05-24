using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : Singleton<Plane>
{
    [SerializeField] protected List<Enemy> enemies = new List<Enemy>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constans.TAG_ENEMY))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (!enemy.isDie)
            {
                enemies.Add(enemy);
            }
            else
            {
                enemies.Remove(enemy);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Constans.TAG_ENEMY))
        {
            enemies.Remove(other.GetComponent<Enemy>());
        }
    }

    public Enemy GetEnemy()
    {
        if (enemies.Count == 0) return null;
        Enemy enemy = null;
        float maxdistane = float.MaxValue;
        for (int i = 0; i < enemies.Count; i++)
        {

            if (enemies[i].DistanceToLose() < maxdistane)
            {
                maxdistane = enemies[i].DistanceToLose();
                enemy = enemies[i];
            }
        }
        if (!enemy.isDie) return enemy;
        else
        {
            enemies.Remove(enemy);
            return GetEnemy();
        }

    }

}
