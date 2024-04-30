using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyPathFinder : PathFinder
{
    public GameObject[] routeList;
    public List<Node> GetNodeList()
    {
        List<Node> path = new List<Node>();
        int count = routeList.Length;
        for(int i=0; i<count; i++)
        {
            Vector2Int coordinate = GameManager.GridM.GetCoordinatesFromPosition(routeList[i].transform.position);
            Node node = GameManager.GridM.GetNode(coordinate);
            path.Add(node);
        }
        return path;
    }

    public override List<Node> SearchRoute()
    {
        List<Node> path = new List<Node>();
        path =  GetNodeList();
        return path;
    }

    public override List<Node> SearchRoute(Vector2Int coordinate)
    {
        List<Node> path = new List<Node>();
        path = GetNodeList();
        return path;
    }

    public override bool CanBlock(Vector2Int _coordinate)
    {
        return true;
    }
}
