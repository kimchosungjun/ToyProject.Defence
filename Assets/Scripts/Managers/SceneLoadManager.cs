using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoadManager 
{
    public SceneName currentSceneName { get; set; } = SceneName.Lobby;
    /// <summary>
    /// Input SceneName 
    /// </summary>
    /// <param name="_sceneName"></param>
    public void LoadScene(SceneName _sceneName)
    {
        switch (_sceneName)
        {
            case SceneName.Lobby:
                SceneManager.LoadScene("Lobby");
                break;
            case SceneName.Easy:
                SceneManager.LoadScene("Easy");
                break;
            case SceneName.Hard:
                SceneManager.LoadScene("Hard");
                break;
            case SceneName.Endding:
                SceneManager.LoadScene("Endding");
                break;
        }
    }
}
