using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTowerLocator : TargetLocator
{
    #region Variable
    [SerializeField] protected ShotBullet[] shotBullets;
    [SerializeField] protected float arrowSpeed = 0.01f;
    #endregion

    #region Seek Enemy & Shoot Bullet  
    public override void FindClosetTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closetTarget = null;
        float maxDist = Mathf.Infinity;
        foreach (Enemy enemy in enemies)
        {
            float targetDistancce = Vector3.Distance(transform.position, enemy.transform.position);
            if (targetDistancce < maxDist)
            {
                closetTarget = enemy.transform;
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
        if (targetDistance < detectRange)
        {
            weapon.LookAt(target);
            if(canShoot)
                Attack(target);
        }
    }

    public override void Attack(Transform _target)
    {
        canShoot = false;
        int count = shotBullets.Length;
        GameObject go;
        for (int idx = 0; idx < count; idx++)
        {
            go = shotBullets[idx].gameObject;
            if (go.activeSelf)
                continue;
            go.SetActive(true);
            shotBullets[idx].TowardTarget(_target, arrowSpeed);
            shotBullets[idx].towerData = towerData;
            StartCoroutine("CoolDown", towerData.attackCoolTime);
            return;
        }

        GameObject newBullet = Instantiate(shotBullets[0].gameObject, weapon.position, Quaternion.identity);
        newBullet.transform.parent = shotBullets[0].transform.parent;
        ShotBullet newShotBullet = newBullet.GetComponent<ShotBullet>();
        newShotBullet.TowardTarget(_target, arrowSpeed);
        newShotBullet.towerData = towerData;
        StartCoroutine("CoolDown", towerData.attackCoolTime);
    }
    #endregion
}
