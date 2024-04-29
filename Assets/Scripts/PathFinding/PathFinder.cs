using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    #region Variable
    [Header("시작, 끝점")]
    [SerializeField] private Vector2Int startCoordinates;
    [SerializeField] private Vector2Int destinationCoordinates;
    public Vector2Int StartCoordiantes { get { return startCoordinates; } }
    public Vector2Int DestinationCoordinates { get { return destinationCoordinates; } }
    private Node startNode;
    private Node destinationNode;
    private Node currentSearchNode;
    
    // Search Variable
    private Queue<Node> frontier = new Queue<Node>();
    private Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();
    private Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    private Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    #endregion

    #region Virtual Method
    public virtual List<Node> SearchRoute() { return null; }
    public virtual List<Node> SearchRoute(Vector2Int coordinate) { return null; }
    #endregion

    private void Start()
    {
        GameManager.GridM.PathFinder = this;
        //SearchRoute();
        //grid = GameManager.GridM.Grid;
        //startNode = grid[startCoordinates];
        //destinationNode = grid[destinationCoordinates];
        //GetNewPath();
    }

    public virtual List<Node> GetNewPath() { return null; }
    public virtual List<Node> GetNewPath(Vector2Int coordinate) { return null; }
    
    //public List<Node> GetNewPath()
    //{
    //    return GetNewPath(startCoordinates);
    //}
    //public List<Node> GetNewPath(Vector2Int coordinates)
    //{
    //    gridManager.ResetNodes();
    //    BFS(coordinates);
    //    return BuildPath();
    //}

    void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();
        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighborCoords = currentSearchNode.coordinates + direction;
            if (grid.ContainsKey(neighborCoords))
            {
                neighbors.Add(grid[neighborCoords]);
               
            }
        }
        foreach(Node neighbor in neighbors)
        {
            if(!reached.ContainsKey(neighbor.coordinates)&& neighbor.isWalkable)
            {
                neighbor.connectedTo = currentSearchNode;
                reached.Add(neighbor.coordinates,neighbor);
                frontier.Enqueue(neighbor);
            }
        }
    }

    void BFS(Vector2Int coordiantes)
    {
        startNode.isWalkable = true;
        destinationNode.isWalkable = true;
        frontier.Clear();
        reached.Clear();
        bool isRunning = true;
       
        frontier.Enqueue(grid[coordiantes]);
        reached.Add(coordiantes, grid[coordiantes]);

        while (frontier.Count > 0 && isRunning)
        {
            currentSearchNode = frontier.Dequeue();
            currentSearchNode.isExplored = true;
            ExploreNeighbors();
            if (currentSearchNode.coordinates == destinationCoordinates)
                isRunning = false;
        }
    }
    List<Node> BuildPath()
    {
        List<Node> path = new List<Node>();
        Node currentNode = destinationNode;
        path.Add(currentNode);
        currentNode.isPath = true;
        while (currentNode.connectedTo != null)
        {
            currentNode = currentNode.connectedTo;
            path.Add(currentNode);
            currentNode.isPath = true;
        }
        path.Reverse();
        return path;
    }

    public bool WillBlockPath(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            bool previousState = grid[coordinates].isWalkable;
            grid[coordinates].isWalkable = false;
            List<Node> newPath = GetNewPath();
            grid[coordinates].isWalkable = previousState;
            if (newPath.Count <= 1)
            {
                GetNewPath();
                return true;
            }
        }
        return false;
    }

    public void NotifyReceivers()
    {
        BroadcastMessage("RecalculatePath", false, SendMessageOptions.DontRequireReceiver);
    }
}
