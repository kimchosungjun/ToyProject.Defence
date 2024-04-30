using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager
{
    #region Variable
    // 맵의 총 크기
    private Vector2Int gridSize = new Vector2Int(8,8);
    public Vector2Int GridSize { get { return gridSize; } set { gridSize = value; CreateGrid(); } }
    // 격자의 크기
    private int unityGridSize = 2;
    public int UnityGridSize{ get{ return unityGridSize; } }
    // 좌표가 키인 노드를 저장한 사전
    private Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Grid { get { return grid; } }
    // 경로를 찾는 함수
    private PathFinder pathFinder =null;
    public PathFinder PathFinder { get { return pathFinder; } set { pathFinder = value; } } 
    #endregion

    public Node GetNode(Vector2Int key)
    {
        if (grid.ContainsKey(key))
            return grid[key];
        return null;
    }

    public void BlockNode(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            grid[coordinates].canMoveNode = false;
        }
    }

    public void ResetNodes()
    {
        foreach(KeyValuePair<Vector2Int,Node> entry in grid)
        {
            entry.Value.connectedTo = null;
            entry.Value.canVisitNode = false;
        }
    }

    public Vector2Int GetCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();
        coordinates.x = Mathf.RoundToInt(position.x / unityGridSize);
        coordinates.y = Mathf.RoundToInt(position.z / unityGridSize);
        return coordinates;
    }

    public Vector3 GetPositionFromCoordinates(Vector2Int coordinates)
    {
        Vector3 position = new Vector3();
        position.x = coordinates.x * unityGridSize;
        position.z = coordinates.y * unityGridSize;
        return position;
    }

    public void CreateGrid()
    {
        for(int x=0; x<gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                grid.Add(coordinates, new Node(coordinates, true));
            }
        }
    }
}
