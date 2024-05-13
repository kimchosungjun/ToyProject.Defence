using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{
    public ScriptableTower towerData;

    public void OnEnable()
    {
        transform.localPosition = Vector3.zero;
    }

    public void OnDisable()
    {
        StopAllCoroutines();
    }

    public void TowardTarget(Transform _target, float _speed)
    {
        Vector3 direction = _target.position - transform.position ;
        direction.y = 0;
        direction = direction.normalized;
        StartCoroutine(ToTarget(direction, _speed));
    }

    public IEnumerator ToTarget(Vector3 _dir, float _speed)
    {
        float curTime = 0f;
        while (curTime < 5f)
        {
            curTime += Time.deltaTime;
            transform.Translate(_dir* _speed * Time.deltaTime);
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
