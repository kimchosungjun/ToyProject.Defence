using UnityEngine;
using TMPro;

public class GoldUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    private bool isTurnOn = false;

    public void ChangeGoldText(int _money)
    {
        if (!isTurnOn)
        {
            isTurnOn = true;
            gameObject.SetActive(isTurnOn);
        }
        goldText.text = "Gold : " + _money;
    }
}
