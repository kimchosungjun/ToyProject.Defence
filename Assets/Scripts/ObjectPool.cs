using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("0은 원숭이, 1은 참새")]
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] [Range(0, 50)] private int enemyPoolSizes = 5;
    [SerializeField] [Range(0.1f, 30f)] private float[] spawnTimers;
    private List<List<GameObject>> enemyList = new List<List<GameObject>>();

    public void MonsterSpawn()
    {
        
        int enemyTypeCount = enemyPrefabs.Length;

        for (int i = 0; i < enemyTypeCount; i++)
        {
            List<GameObject> _enemyList = new List<GameObject>();
            GameObject enemyTypeParent = new GameObject(enemyPrefabs[i].name + "Parent");
            enemyTypeParent.transform.parent = this.gameObject.transform;
            enemyTypeParent.transform.position = Vector3.zero;
            for (int k = 0; k < enemyPoolSizes; k++)
            {
                GameObject enemy = Instantiate(enemyPrefabs[i]);
                enemy.transform.parent = enemyTypeParent.transform;
                enemy.transform.position = new Vector3(2,0,2);
                _enemyList.Add(enemy);
                enemy.SetActive(false);
            }
            enemyList.Add(_enemyList);
        }
        SpawnEnemy();
    }


    public void SpawnEnemy()
    {
        int count = enemyPrefabs.Length;
        for (int i = 0; i < count; i++)
        {
            StartCoroutine(SpawnEnemyCor(i));
        }
    }

    public IEnumerator SpawnEnemyCor(int _index)
    {
        bool _isFind = false;
        int count = enemyList[_index].Count;
        for (int i=0; i<count; i++)
        {
            if (!enemyList[_index][i].activeSelf)
            {
                enemyList[_index][i].SetActive(true);
                _isFind = true;
                break;
            }
        }
        if (!_isFind)
        {
            GameObject newEnemy = Instantiate(enemyPrefabs[_index]);
            newEnemy.transform.parent = enemyList[_index][0].transform.parent;
            newEnemy.transform.position = Vector3.zero;
            enemyList[_index].Add(newEnemy);
        }
        yield return new WaitForSeconds(spawnTimers[_index]);
        StartCoroutine(SpawnEnemyCor(_index));
    }
}
