using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolType
{
    None,
    Bullet,
    ZombieDefaul,
    ZombieRed,
    Crab,
    Boss

}
public class ObjectPooling : Singleton<ObjectPooling>
{
    [System.Serializable]
    public class Pool
    {
        public GameObject poolPrefab;
        public Transform parents;
        public int counts;
        public bool canGrow;
        public PoolType poolType;
    }
    [SerializeField] protected List<Pool> listPools = new List<Pool>();
    protected Dictionary<PoolType, Queue<GameObject>> dicPools = new Dictionary<PoolType, Queue<GameObject>>();

    void Awake()
    {
        for (int i = 0; i < listPools.Count; i++)
        {
            Queue<GameObject> gameObjects = new Queue<GameObject>();
            for (int j = 0; j < listPools[i].counts; j++)
            {
                GameObject go = Instantiate(listPools[i].poolPrefab, listPools[i].parents);
                go.gameObject.SetActive(false);
                gameObjects.Enqueue(go);
            }
            dicPools.Add(listPools[i].poolType, gameObjects);
        }
    }

    public GameObject GetGameObject(PoolType poolType, Vector3 pos)
    {
        for (int i = 0; i < listPools.Count; i++)
        {
            if (listPools[i].poolType == poolType)
            {
                if (dicPools[poolType].Count > 0)
                {
                    GameObject go = dicPools[poolType].Dequeue();
                    go.gameObject.SetActive(true);
                    go.transform.position = pos;
                    return go;
                }
                else if (listPools[i].canGrow)
                {
                    GameObject go = Instantiate(listPools[i].poolPrefab, listPools[i].parents);
                    go.transform.position = pos;
                    return go;
                }
                else
                {
                    return null;
                }
            }
        }
        return null;
    }


    public void ReturnGameObject(PoolType type, GameObject gameObject)
    {
        gameObject.SetActive(false);
        dicPools[type].Enqueue(gameObject);
    }
}
