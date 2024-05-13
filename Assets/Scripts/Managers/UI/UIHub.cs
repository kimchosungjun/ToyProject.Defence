using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHub : MonoBehaviour
{
    [SerializeField] public StartUI startUI=null;
    [SerializeField] public EndUI endUI = null;
    [SerializeField] public HPUI hpUI = null;
    [SerializeField] public GoldUI goldUI = null;
    [SerializeField] public TowerUI towerUI = null;
    [SerializeField] public GameOverUI gameOverUI = null;
    [SerializeField] public TimerUI timerUI = null;
    private void Start()
    {
        GameManager.UIM.UIH = this;
    }
}
