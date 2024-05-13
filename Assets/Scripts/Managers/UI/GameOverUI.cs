using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Text endingText;
    public void GameLose()
    {
        gameObject.SetActive(true);
        endingText.text = "�й��߽��ϴ�..";
    }
    
    public void GameWin()
    {
        gameObject.SetActive(true);
        endingText.text = "�¸��߽��ϴ�!!";
        //GameManager.UIM.UIH.timerUI.StopTimer();
    }

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;    
    }

    public void ReturnScene()
    {
        GameManager.SceneLM.LoadScene(SceneName.Lobby);
        gameObject.SetActive(false);
    }
}
