using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    public void StartGame() { GameManager.SceneLM.LoadScene(SceneName.Hard); }
    public void ResumeGame() {  }
}
