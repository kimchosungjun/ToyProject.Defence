using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveStartUI : MonoBehaviour
{
    public Button btn;
    public void StartWave()
    {
        ObjectPool pool = GameObject.FindWithTag("Pool").GetComponent<ObjectPool>();
        pool.MonsterSpawn();
        GameManager.SystemM.StartGame();
        btn.interactable = false;
    }
}
