using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyGameData : MonoBehaviour
{
    public ScriptableStage stageData;

    public void Awake()
    {
        StartCoroutine(SetData());
    }

    public IEnumerator SetData()
    {
        yield return new WaitForEndOfFrame();
        GameManager.SystemM.SetHP(stageData.startHp);
        GameManager.SystemM.SetMoney(stageData.startMoney);
        GameManager.SystemM.SetTimer(stageData.stageTime);
        GameManager.GridM.GridSize = stageData.stageStartSize;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            GameManager.SystemM.WinGame();
    }
}
