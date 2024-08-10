using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGameplay : CustomCanvas
{
    [SerializeField] private TextMeshProUGUI _moneyText;


    private void Start()
    {
        UpdateMoneyText();
    }
    

    private void UpdateMoneyText()
    {
        _moneyText.text = CurrencyManager.Instance.GetCurrencyString();
    }
}