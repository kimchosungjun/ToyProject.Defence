using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleUI : MonoBehaviour
{
    public TargetLocator targetLocator;
    public enum HandleUIType
    {
        Upgrade,
        Sell
    }

    public HandleUIType currentType;

    public void Upgrade()
    {
        if (GameManager.SystemM.CanUseMoney(targetLocator.towerData.upgradeMoney))
        {
            GameManager.SystemM.DecreaseMoney(targetLocator.towerData.upgradeMoney);
            targetLocator.towerData.attackCoolTime -= targetLocator.towerData.attackCoolTimeUpgrade;
            targetLocator.towerData.damagePoint += targetLocator.towerData.upgradeDamage;
            targetLocator.towerData.decreaseValue += targetLocator.towerData.decreaseValueUpgrade;
            targetLocator.towerData.curUpgradeLevel += 1;
        }
        else
            targetLocator.OnOffHandleUI();
    }

    public void OnEnable()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
