using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("ÄÄÆ÷³ÍÆ®")]
    [SerializeField] private ScriptableEnemy enemyData;
    [SerializeField] private EnemyMover enemyMover;
    private int currentHp;

    private void OnEnable()
    {
        currentHp = enemyData.healthPoint;
    }

    #region System Logic Method

    #endregion

    #region HP Logic Method
    public virtual void HitByTower(ScriptableTower _towerData) 
    {
        currentHp -= _towerData.damagePoint;
        HitByArrowType(_towerData);
        if (currentHp <= 0)
            DeathEnemy();
    }

    public virtual void DeathEnemy()
    {
        Debug.Log(enemyData.rewardMoney);
        gameObject.SetActive(false);
    }

    public virtual void HitByArrowType(ScriptableTower _towerData)
    {
        ArrowType arrowType = _towerData.arrowType;
        switch (arrowType)
        {
            case ArrowType.Normal:
                break;
            case ArrowType.Slow:
                StartCoroutine(DeBuffTimer(_towerData.debuffTime, _towerData.decreaseValue));
                break;
        }
    }
    public IEnumerator DeBuffTimer(float _timer, int _decreaseValue)
    {
        enemyMover.MoveSpeed = enemyData.moveSpeed-_decreaseValue;
        float currentTime = 0f;
        while (currentTime < _timer)
        {
            currentTime += Time.deltaTime;
            yield return null;
        }
        enemyMover.MoveSpeed = enemyData.moveSpeed;
    }
    #endregion
}
