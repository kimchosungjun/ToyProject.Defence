using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHub : MonoBehaviour
{
    [SerializeField] public StartUI startUI;
    [SerializeField] public EndUI endUI;
    [SerializeField] public HPUI hpUI;
    [SerializeField] public GoldUI goldUI;
    [SerializeField] public TowerUI towerUI;
    [SerializeField] public GameOverUI gameOverUI;

    private void Awake()
    {
        GameManager.UIM.UIH = this;
    }
}
