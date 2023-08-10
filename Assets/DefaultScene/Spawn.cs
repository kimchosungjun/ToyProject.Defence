using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 spawnPos = new Vector3(0,0,0);
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefab);
            prefab.transform.position = spawnPos;
            spawnPos += Vector3.forward;
            Debug.Log(prefab.name);
        }
    }

}
