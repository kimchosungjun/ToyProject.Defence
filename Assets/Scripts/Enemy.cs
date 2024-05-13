using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("ÄÄÆ÷³ÍÆ®")]
    [SerializeField] private ScriptableEnemy enemyData;
    [SerializeField] private EnemyMover enemyMover;
    private int currentHp;
    private bool isCollideParticle = false;
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
        GameManager.SystemM.EarnMoney(enemyData.rewardMoney);
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
                DeBuffTimer(_towerData.decreaseValue);
                break;
        }
    }
    public void DeBuffTimer(float _decreaseValue)
    {
        enemyMover.MoveSpeed = enemyData.moveSpeed-_decreaseValue;
    }
    public IEnumerator DeBuffTimerCor(float _timer, int _decreaseValue)
    {
        enemyMover.MoveSpeed = enemyData.moveSpeed - _decreaseValue;
        float currentTime = 0f;
        while (currentTime < _timer)
        {
            currentTime += Time.deltaTime;
            yield return null;
        }
        enemyMover.MoveSpeed = enemyData.moveSpeed;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            HitByTower(other.GetComponent<ShotBullet>().towerData);
            other.gameObject.SetActive(false);

        }

        if (other.CompareTag("P"))
        {
            HitByTower(other.GetComponent<ParticleBullet>().towerData);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("P"))
        {
            DeBuffTimer(-other.GetComponent<ParticleBullet>().towerData.decreaseValue);
        }
    }
    #endregion
}
