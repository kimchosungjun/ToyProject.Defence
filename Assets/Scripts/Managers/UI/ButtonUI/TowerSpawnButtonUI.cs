using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerSpawnButtonUI : MonoBehaviour
{
    [SerializeField] private ScriptableTower towerData;
    [SerializeField] private TextMeshProUGUI goldText;
    private void Awake()
    {
        if (goldText == null)
            goldText = GetComponentInChildren<TextMeshProUGUI>();
        goldText.text = "Price " + towerData.buildMoney;
    }

    public void SpawnTower()
    {
        GameManager.UIM.UIH.towerUI.BuildTower(towerData);
    }
}
