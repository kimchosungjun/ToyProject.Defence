using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardPathFinder : PathFinder
{
    #region Variable
    private bool canReachDestination = false;
    //private Node startNode;
    private Node destinationNode;
    private Node currentSearchNode;

    // Search Variable
    private Queue<Node> routeQueue = new Queue<Node>();
    private Vector2Int[] searchDirection = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    private Dictionary<Vector2Int, Node> exploreDictionary = new Dictionary<Vector2Int, Node>();
    private Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    #endregion

    protected override void Start()
    {
        base.Start();
        grid = GameManager.GridM.Grid;
        // startNode = grid[startCoordinate];
        destinationNode = grid[destinationCoordinate];
    }

    #region Search Path Method
    public override List<Node> SearchRoute()
    {
        return SearchRoute(startCoordinate);
    }
    public override List<Node> SearchRoute(Vector2Int _coordinate)
    {
        GameManager.GridM.ResetNodes();
        BFS(_coordinate);
        return BuildPath();
    }
    public override bool CanBlock(Vector2Int _coordinate)
    {
        if (grid.ContainsKey(_coordinate))
        {
            bool previousState = grid[_coordinate].canMoveNode;
            grid[_coordinate].canMoveNode = false;
            grid[_coordinate].canMoveNode = previousState;
            if (canReachDestination)
            {
                SearchRoute();
                return true;
            }
            SearchRoute();
        }
        return false;
    }
    void ExploreNextRoute()
    {
        List<Node> nextRouteList= new List<Node>();
        int directionCount = searchDirection.Length;
        for(int idx=0; idx<directionCount; idx++)
        {
            Vector2Int next = currentSearchNode.coordinate + searchDirection[idx];
            if (grid.ContainsKey(next))
                nextRouteList.Add(grid[next]);
        }

        int nextRouteCount = nextRouteList.Count;
        for(int idx =0; idx<nextRouteCount; idx++)
        {
            if (!exploreDictionary.ContainsKey(nextRouteList[idx].coordinate) && nextRouteList[idx].canMoveNode)
            {
                nextRouteList[idx].connectedTo = currentSearchNode;
                exploreDictionary.Add(nextRouteList[idx].coordinate, nextRouteList[idx]);
                routeQueue.Enqueue(nextRouteList[idx]);
            }
        }
    }
    void BFS(Vector2Int _coordiante)
    {
        //startNode.canMoveNode = true;
        destinationNode.canMoveNode = true;
        routeQueue.Clear();
        exploreDictionary.Clear();
        routeQueue.Enqueue(grid[_coordiante]);
        exploreDictionary.Add(_coordiante, grid[_coordiante]);

        while (routeQueue.Count > 0)
        {
            currentSearchNode = routeQueue.Dequeue();
            currentSearchNode.canVisitNode = true;
            ExploreNextRoute();
            if (currentSearchNode.coordinate == destinationCoordinate)
            {
                canReachDestination = true;
                destinationNode.canMoveNode = false;
                return;
            }
        }
        canReachDestination = false;
        destinationNode.canMoveNode = false;
    }
    List<Node> BuildPath()
    {
        List<Node> path = new List<Node>();
        Node currentNode = destinationNode;
        path.Add(currentNode);
        while (currentNode.connectedTo != null)
        {
            currentNode = currentNode.connectedTo;
            path.Add(currentNode);
        }
        path.Reverse();
        return path;
    }
    #endregion

}
