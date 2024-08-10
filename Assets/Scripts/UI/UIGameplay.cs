using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGameplay : CustomCanvas
{
    [SerializeField] private TextMeshProUGUI _moneyText;


    private void Start()
    {
        UpdateMoneyText();
        CurrencyManager.OnBalanceChanged += UpdateMoneyText;
    }

    private void OnDestroy()
    {
        CurrencyManager.OnBalanceChanged -= UpdateMoneyText;
    }


    private void UpdateMoneyText()
    {
        _moneyText.text = CurrencyManager.Instance.GetCurrencyString();
    }
}