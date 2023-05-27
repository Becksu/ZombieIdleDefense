using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : Singleton<Level>
{
    public int level;
    public float enemyCounts;
    public float enemyCountsMax;
    public GameObject enemyPrefab;
    public List<Enemy> enemys = new List<Enemy>();


    private void Start()
    {
        enemyCountsMax = DataManager.Instance.waveGameDT * 5 / 3 + 5;
        enemyCounts = enemyCountsMax;
        InvokeRepeating(nameof(SpawnerEnemy),0f, 1f);
    }
    public void SpawnerEnemy()
    {
        float posX = Random.Range(-12, 13);
        float posZ = Random.Range(-28, -30);
        GameObject go = ObjectPooling.Instance.GetGameObject(PoolType.Enemy, new Vector3(posX, 0, posZ));
        Enemy enemy = go.GetComponent<Enemy>();
        enemy.OnInit();
        enemys.Add(enemy);
        enemy.OnWinGame += LevelManager.Instance.WinGame;
        enemyCountsMax--;
        if (enemyCountsMax > 0) return;
        CancelInvoke();
    }
    public void NextWave()
    {
        DataManager.Instance.waveGameDT++;

    }
    public void NextLevel()
    {

    }
}
