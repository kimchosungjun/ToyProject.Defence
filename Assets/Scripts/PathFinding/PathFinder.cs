using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    #region Variable
    [Header("시작, 끝점")]
    [SerializeField] protected Vector2Int startCoordinate;
    [SerializeField] protected Vector2Int destinationCoordinate;
    public Vector2Int StartCoordiante { get { return startCoordinate; } }
    public Vector2Int DestinationCoordinate { get { return destinationCoordinate; } }
   
    #endregion

    #region Virtual Method
    public virtual List<Node> SearchRoute() { return null; }
    public virtual List<Node> SearchRoute(Vector2Int coordinate) { return null; }
    public virtual bool CanBlock(Vector2Int _coordinate) { return true; }
    #endregion

    protected virtual void Start()
    {
        GameManager.GridM.PathFinder = this;
    }

    public void NotifyReceivers()
    {
        BroadcastMessage("RecalculatePath", false, SendMessageOptions.DontRequireReceiver);
    }
}
