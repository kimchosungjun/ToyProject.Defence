using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    #region Variable
    [Header("적의 이동속도")]
    [SerializeField] [Range(0f,5f)] private float speed = 1f;
    [SerializeField] private Enemy enemy;
    
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
        ReturnStartingPoint();
        RecalculatePath(true);
    }

    void ReturnStartingPoint()
    {
        transform.position = GameManager.GridM.GetPositionFromCoordinates(PathFinder.StartCoordiantes);
    }

    void RecalculatePath(bool _isResetPath = true)
    {
        Vector2Int coordinates = new Vector2Int();

        if (_isResetPath)
            coordinates = PathFinder.StartCoordiantes;
        else
            coordinates = GameManager.GridM.GetCoordinatesFromPosition(transform.position);

        StopAllCoroutines();
        path.Clear();
        path = PathFinder.SearchRoute();
        StartCoroutine(FollowPath());
    }

    

    IEnumerator FollowPath()
    {
        for(int i=1; i<path.Count; i++)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = GameManager.GridM.GetPositionFromCoordinates(path[i].coordinates);
            float travelPercent = 0f;
            transform.LookAt(endPos);
            while(travelPercent<1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }

    void FinishPath()
    {
        //enemy.StealGold();
        gameObject.SetActive(false);
    }
}
