using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] private Transform weapon;
    [SerializeField] private GameObject[] arrowObjects;
    [SerializeField] private float range = 15f;
    [SerializeField] private float arrowSpeed = 0.01f;
    [SerializeField] public ScriptableTower towerData;
    private Transform target;
    private bool canShoot = true;

    void Update()
    {
        FindClosetTarget();
        AimWeapon();
        ArrowUpdate();
    }

    public void FindClosetTarget()
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

    public void AimWeapon()
    {
        if (target == null)
            return;
        float targetDistance = Vector3.Distance(transform.position, target.position);
        if (targetDistance < range && canShoot)
        {
            weapon.LookAt(target);
            Attack();
        }
    }

    public void Attack()
    {
        canShoot = false;
        int count = arrowObjects.Length;
        for (int idx = 0; idx < count; idx++)
        {
            if (arrowObjects[idx].activeSelf)
                continue;
            arrowObjects[idx].SetActive(true);
            arrowObjects[idx].transform.LookAt(target);
            StartCoroutine("CoolDown",towerData.attackCoolTime);
            return;
        }
        GameObject go = Instantiate(arrowObjects[0], weapon.position, Quaternion.identity);
        go.transform.parent = arrowObjects[0].transform.parent;
        StartCoroutine("CoolDown", towerData.attackCoolTime);
    }

    public IEnumerator CoolDown(float _timer)
    {
        yield return new WaitForSeconds(_timer);
        canShoot = true;
    }

    public void ArrowUpdate()
    {
        int count = arrowObjects.Length;
        for(int idx=0; idx<count; idx++)
        {
            if (!arrowObjects[idx].activeSelf)
                continue;
            arrowObjects[idx].transform.position += arrowObjects[idx].transform.forward * arrowSpeed;
            if (Vector3.Distance(arrowObjects[idx].transform.position, transform.position) > range)
                arrowObjects[idx].SetActive(false);
        }
    }
}
