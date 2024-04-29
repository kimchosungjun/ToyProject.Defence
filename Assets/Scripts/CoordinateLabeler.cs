using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [Header("»ö±ò : ÇÏ¾á»ö(Åë·Î) / È¸»ö(¸·ÈùÅë·Î) / ³ë¶û»ö(Áö³ª¿Â°÷)")]
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color blockedColor = Color.gray;
    [SerializeField] private Color exploredColor = Color.yellow;

    [Header("ÄÄÆ÷³ÍÆ®")]
    [SerializeField] private TextMeshPro label;

    Vector2Int coordinates = new Vector2Int();
    
    void Awake()
    {
        if(label==null)
            label = gameObject.GetComponent<TextMeshPro>();
        //label.enabled = false;
        DisplayCoordinates();
    }

    void Update()
    {
        DisplayCoordinates();
        UpdateObjectName();
        SetLabelColor();
        ToggleLabels();
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
            label.enabled = !label.IsActive();
    }

    void DisplayCoordinates()
    {
        int unityGirdSize = GameManager.GridM.UnityGridSize;
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x/ unityGirdSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z/ unityGirdSize);
        label.text = "("+coordinates.x+","+coordinates.y+ ")";
    }

    void UpdateObjectName()
    {
        //transform.parent.name = coordinates.ToString();
    }
    void SetLabelColor()
    {
        //if (gridManager == null) { return; }
        //Node node = gridManager.GetNode(coordinates);
        //if (node == null) { return; }
        //if (!node.isWalkable)
        //    label.color = blockedColor;
        //else if (node.isExplored)
        //    label.color = exploredColor;
        //else
        //    label.color = defaultColor;
    }

}
