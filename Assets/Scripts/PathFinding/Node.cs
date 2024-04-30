using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Node 
{
    public Vector2Int coordinate;
    public bool canMoveNode;
    public bool canVisitNode;
    public Node connectedTo;
    
    public Node(Vector2Int coordinates, bool _canMoveNode)
    {
        this.coordinate = coordinates;
        this.canMoveNode= _canMoveNode;
    }
}
