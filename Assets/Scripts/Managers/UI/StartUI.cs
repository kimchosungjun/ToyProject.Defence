using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    public void StartEasyMode() { GameManager.SceneLM.LoadScene(SceneName.Easy); }
    public void StartHardMode() { GameManager.SceneLM.LoadScene(SceneName.Hard); }
    public void ResumeGame() {  }
}
