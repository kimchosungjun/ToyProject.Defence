using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager
{
    public int currentMoney = 0;
    public int currentHp = 0;
    public float stageTimer = 0f;
    
    #region Money Manage Method
    public void ChangeMoneyText(int _money)
    {
        GameManager.UIM.UIH.goldUI.ChangeGoldText(_money);
    }

    public void SetMoney(int _money)
    {
        currentMoney = _money;
        ChangeMoneyText(currentMoney);
    }

    public void EarnMoney(int _money)
    {
        currentMoney += _money;
        ChangeMoneyText(currentMoney);
    }

    public void DecreaseMoney(int _money)
    {
        currentMoney -= _money;
        ChangeMoneyText(currentMoney);
    }

    public bool CanUseMoney(int _money)
    {
        if (currentMoney - _money < 0)
            return false;
        return true;
    }
    #endregion

    #region Playing Game System Method

    public void ChangeHPText(int _hp)
    {
        GameManager.UIM.UIH.hpUI.ChangeHPText(_hp);
    }

    public void SetHP(int _hp)
    {
        currentHp = _hp;
        ChangeHPText(currentHp);
    }

    public void DecreaseHP(int _hp)
    {
        currentHp -= _hp;
        if (currentHp <= 0)
        {
            currentHp = 0;
            ChangeHPText(currentHp);
            LoseGame();
            return;
        }
        ChangeHPText(currentHp);
    }

    public void WinGame()
    {
        GameManager.UIM.UIH.gameOverUI.GameWin();
    }

    public void LoseGame()
    {
        GameManager.UIM.UIH.gameOverUI.GameLose();
    }
    #endregion

    #region Timer
    public void StartGame()
    {
        GameManager.UIM.UIH.timerUI.StartTimer();
    } 

    public void SetTimer(float _timer)
    {
        stageTimer = _timer;
        GameManager.UIM.UIH.timerUI.SetTimer(_timer);
    }
    #endregion
}
