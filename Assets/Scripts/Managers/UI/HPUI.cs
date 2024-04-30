using UnityEngine;
using TMPro;

public class HPUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpText;
    private bool isTurnOn = false;

    public void ChangeHPText(int _hp)
    {
        if (!isTurnOn)
        {
            isTurnOn = true;
            gameObject.SetActive(isTurnOn);
        }
        hpText.text = "HP : " + _hp;
    }
}
