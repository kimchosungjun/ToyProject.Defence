using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    #region Common Variable
    [SerializeField] protected Transform weapon;
    [SerializeField] protected float detectRange = 15f;
    [SerializeField] public ScriptableTower towerData;
    protected Transform target;
    protected bool canShoot = true;
    public GameObject handleUIObject;
    public bool isActiveUI = false;
    #endregion

    #region Unity Life Cycle
    protected virtual void Update()
    {
        FindClosetTarget();
        AimWeapon();
    }
    #endregion

    #region Seek Enemy & Shoot Bullet Virtual Method
    public virtual void FindClosetTarget() { }

    public virtual void AimWeapon() { }

    public virtual void Attack(Transform _target) { }
    #endregion

    #region Coroutine
    public IEnumerator CoolDown(float _timer)
    {
        yield return new WaitForSeconds(_timer);
        canShoot = true;
    }
    public void OnMouseDown()
    {
        if(towerData.curUpgradeLevel<towerData.canUpgradeLevel)
            OnOffHandleUI();
    }

    public void OnOffHandleUI()
    {
        isActiveUI = !isActiveUI;
        handleUIObject.SetActive(isActiveUI);
    }
    #endregion
}
