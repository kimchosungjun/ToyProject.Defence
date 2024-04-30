using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyGameData : MonoBehaviour
{
    public int stageStartHP;
    public int stageStartMoney;
    public Vector2Int stageStartSize;

    public void Awake()
    {
        StartCoroutine(SetData());
    }

    public IEnumerator SetData()
    {
        yield return new WaitForEndOfFrame();
        GameManager.SystemM.SetHP(stageStartHP);
        GameManager.SystemM.SetMoney(stageStartMoney);
        GameManager.GridM.GridSize = stageStartSize;
    }
}
