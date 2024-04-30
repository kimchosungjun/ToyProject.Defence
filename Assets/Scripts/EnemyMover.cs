using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    #region Variable
    [Header("ÄÄÆ÷³ÍÆ®")]
    [SerializeField] private ScriptableEnemy enemyData;

    private float moveSpeed = 0f;
    public float MoveSpeed { set { moveSpeed = value; } }
    private List<Node> path = new List<Node>();
    private PathFinder pathFinder;
    public PathFinder PathFinder
    {
        get
        {
            if (pathFinder == null)
                pathFinder = GameManager.GridM.PathFinder;
            return pathFinder;
        }
    }
    #endregion
    
    void OnEnable()
    {
        moveSpeed = enemyData.moveSpeed;
        ReturnStartingPoint();
        RecalculatePath(true);
    }

    void ReturnStartingPoint()
    {
        transform.position = GameManager.GridM.GetPositionFromCoordinates(PathFinder.StartCoordiante);
    }

    void RecalculatePath(bool _isResetPath = true)
    {
        Vector2Int coordinates = new Vector2Int();

        if (_isResetPath)
            coordinates = PathFinder.StartCoordiante;
        else
            coordinates = GameManager.GridM.GetCoordinatesFromPosition(transform.position);

        StopAllCoroutines();
        path.Clear();
        path = PathFinder.SearchRoute(coordinates);
        StartCoroutine(FollowPath());
    }

    

    IEnumerator FollowPath()
    {
        int pathCount = path.Count; 
        for(int i=1; i<pathCount; i++)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = GameManager.GridM.GetPositionFromCoordinates(path[i].coordinate);
            float travelPercent = 0f;
            transform.LookAt(endPos);
            while(travelPercent<1f)
            {
                travelPercent += Time.deltaTime * moveSpeed;
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }

    void FinishPath()
    {
        GameManager.SystemM.DecreaseHP(enemyData.damagePoint);
        gameObject.SetActive(false);
    }
}
