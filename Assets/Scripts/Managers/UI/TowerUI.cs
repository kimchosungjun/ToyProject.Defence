using UnityEngine;

public class TowerUI : MonoBehaviour
{ 
    private Tile currentTile= null;
    public Tile CurrentTitle { get { return currentTile; } set { currentTile = value; } }
   
    public void BuildTower(ScriptableTower _towerData)
    {
        if (GameManager.SystemM.CanUseMoney(_towerData.buildMoney) && currentTile.IsPlaceable)
        {
            // Áþ´Â´Ù.
            Vector3 buildPosition = GameManager.GridM.GetPositionFromCoordinates(currentTile.Coordinate);
            Instantiate(_towerData.towerObject, buildPosition, Quaternion.identity);
            currentTile.IsPlaceable = false;
        }
        else
            return;
        GameManager.GridM.BlockNode(currentTile.Coordinate);
        GameManager.GridM.PathFinder.NotifyReceivers();
    }

    public void OnOffUI(Tile _tile)
    {
        if (currentTile == null)
        {
            currentTile = _tile;
            return;
        }

        if(currentTile == _tile)
        {
            bool _isActive = gameObject.activeSelf;
            gameObject.SetActive(!_isActive);
        }
        else
        {
            gameObject.SetActive(true);
            currentTile = _tile;
        }
    }
}
