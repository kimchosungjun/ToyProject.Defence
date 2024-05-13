using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTowerLocator : TargetLocator
{
    #region Variable
    [SerializeField] protected GameObject particleAttackObject;
    [SerializeField] protected float attackMaintainTime = 10f;
    bool isAttack = false;
    #endregion

    #region Seek Enemy & Shoot Bullet  
    public override void FindClosetTarget()
    {
        GameObject poolObject = GameObject.FindWithTag("Pool");
        Enemy[] enemies = poolObject.GetComponentsInChildren<Enemy>();
        //Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closetTarget = null;
        float maxDist = Mathf.Infinity;
        int count = enemies.Length;
        for(int i=0; i<count; i++)
        {
            float targetDistancce = Vector3.Distance(transform.position, enemies[i].transform.position);
            if (targetDistancce < maxDist && targetDistancce<detectRange)
            {
                closetTarget = enemies[i].transform;
                maxDist = targetDistancce;
            }
        }
        target = closetTarget;
    }

    public override void AimWeapon()
    {
        if (target == null)
            return;
        float targetDistance = Vector3.Distance(transform.position, target.position);
        if (targetDistance < detectRange && canShoot)
        {
            weapon.LookAt(target);
            if(!isAttack && canShoot)
                Attack(null);
        }
    }

    public override void Attack(Transform _target)
    {
        particleAttackObject.SetActive(true);
        isAttack = true;
        StartCoroutine(OffParticle());
    }

    public IEnumerator OffParticle()
    {
        yield return new WaitForSeconds(attackMaintainTime);
        particleAttackObject.SetActive(false);
        StartCoroutine(CoolDown(towerData.attackCoolTime));
        canShoot = false;
        isAttack = false;
    }
    #endregion
}
