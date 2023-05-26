using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : Singleton<Level>
{
    public int level;
    public float enemyCounts;
    public List<Enemy> enemys = new List<Enemy>();
    public GameObject enemyPrefab;


    private void Start()
    {

        enemyCounts = DataManager.Instance.waveGameDT * 5 / 3;
        for (int i = 0; i < enemyCounts; i++)
        {
            if (enemys.Count <= 0)
            {
                SpawnerEnemy(); continue;
            }
            else
            {
                Invoke(nameof(SpawnerEnemy), 1f);
            }

        }
    }
    public void SpawnerEnemy()
    {
        float posX = Random.Range(-12, 13);
        float posZ = Random.Range(-28, -30);
        GameObject go = Instantiate(enemyPrefab, transform);
        Enemy enemy = go.GetComponent<Enemy>();
        enemy.tF.position = new Vector3(posX, 0, posZ);
        enemys.Add(enemy);
        enemy.OnWinGame += LevelManager.Instance.WinGame;
    }
}
