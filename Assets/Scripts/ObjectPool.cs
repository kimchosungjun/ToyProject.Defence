using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0,50)] int poolSize= 5;
    [SerializeField] [Range(0.1f,30f)] float spawnTimer = 1f;

    [SerializeField] private GameObject[] pool;

    void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for(int i = 0; i<pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTimer);
            EnableObjectInPool();
        }
    }

    void EnableObjectInPool()
    {
        for(int i=0; i <pool.Length; i++)   
        {
            if (!pool[i].activeSelf)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }
}
