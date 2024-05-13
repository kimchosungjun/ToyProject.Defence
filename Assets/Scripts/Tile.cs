using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    [Header("타일의 정보 입력")]
    public Material mat;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } set { isPlaceable = value; } }

    private Vector2Int coordinates = new Vector2Int();
    public Vector2Int Coordinate { get { return coordinates; } }
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

    public void OnMouseDown()
    {
        if (isPlaceable)
        {
            if (GameManager.GridM.GetNode(coordinates).canMoveNode &&
                GameManager.GridM.PathFinder.CanBlock(coordinates) &&
                !EventSystem.current.IsPointerOverGameObject())
                GameManager.UIM.UIH.towerUI.OnOffUI(this);
        }
    }
}
