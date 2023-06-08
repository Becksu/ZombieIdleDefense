using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : Singleton<Level>
{
    protected int index;
    public int level;
    public float enemyCounts;
    public float enemyCountsMax;
    public List<Enemy> enemys = new List<Enemy>();


    private void Start()
    {
       // OnInit();
    }

    public void OnInit()
    {
        index = 0;
        enemyCountsMax = ResourcesManager.Instance.levelInfor.levelInfo[level].poolType.Length; //DataManager.Instance.waveGameDT * 5 / 3 + 5;
        enemyCounts = enemyCountsMax;
        InvokeRepeating(nameof(SpawnerEnemy), 0f, 1f);
    }
    public void SpawnerEnemy()
    {
        float posX = Random.Range(-12, 13);
        float posZ = Random.Range(-28, -30);

        GameObject go = ObjectPooling.Instance.GetGameObject(GetTypeEnemy(level), new Vector3(posX, 0, posZ));
        Enemy enemy = go.GetComponent<Enemy>();
        enemy.OnInit();
        enemys.Add(enemy);
        enemy.OnWinGame += LevelManager.Instance.WinGame;
        enemyCountsMax--;
        if (enemyCountsMax > 0) return;
        CancelInvoke();
    }
    public PoolType GetTypeEnemy(int level)
    {
        PoolType poolType = ResourcesManager.Instance.levelInfor.levelInfo[level].poolType[index];
        index++;
        return poolType;
    }
    public void DespawnLevel()
    {
        for(int i = 0; i < enemys.Count; i++)
        {
            enemys[i].Hp = 0;
            ObjectPooling.Instance.ReturnGameObject(enemys[i].enemyPoolType, enemys[i].gameObject);
        }
        enemys.Clear();
        Destroy(gameObject);
    }
}
