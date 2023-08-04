using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15f;
    Transform target;

    void Update()
    {
        FindClosetTarget();
        AimWeapon();   
    }

    void FindClosetTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closetTarget = null;
        float maxDist = Mathf.Infinity;
        foreach(Enemy enemy in enemies)
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

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        weapon.LookAt(target);
        if (targetDistance < range)
            Attack(true);
        else
            Attack(false);
    }

    void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
