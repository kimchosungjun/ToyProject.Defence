using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    public float currentTimer = 0f;
    public void SetTimer(float _timer)
    {
        currentTimer = _timer;
        int min = (int)_timer / 60;
        int sec = (int)_timer % 60;
        timerText.text = $"{min} : {sec}";
    }

    public void StartTimer()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        while (currentTimer > 0f)
        {
            currentTimer -= Time.deltaTime;
            int min = (int)currentTimer / 60;
            int sec = (int)currentTimer % 60;
            if (sec < 10)
                timerText.text = $"{min} : 0{sec}";
            else
                timerText.text = $"{min} : {sec}";
            
            yield return null;
        }
        GameManager.UIM.UIH.gameOverUI.GameWin();
    }
}
