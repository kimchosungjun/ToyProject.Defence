using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHub : MonoBehaviour
{
    [SerializeField] private StartUI startUI;
    [SerializeField] private EndUI endUI;

    private void Start()
    {
        GameManager.UIM.UIH = this;
    }
}
