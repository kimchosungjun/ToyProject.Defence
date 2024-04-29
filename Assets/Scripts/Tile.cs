using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [Header("Ÿ���� ���� �Է�")]
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    private Vector2Int coordinates = new Vector2Int();
    private PathFinder pathFinder;

    private void Awake()
    {
        coordinates = GameManager.GridM.GetCoordinatesFromPosition(this.transform.position);
    }

    private void Start()
    {
        if(pathFinder==null) { pathFinder= GameManager.GridM.PathFinder; }
        if (!isPlaceable) { GameManager.GridM.BlockNode(coordinates); }
    }


    void OnMouseDown()
    {
        if (GameManager.GridM.GetNode(coordinates).isWalkable && !pathFinder.WillBlockPath(coordinates))
        {
            Debug.Log("Ÿ���� �Ǽ��ϴ�");
        }
    }
}
