using UnityEngine;
using System.Numerics;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance { get; private set; }
    public static event System.Action OnBalanceChanged;

    [field: SerializeField] public BigInteger Money { get; set; } = 0;
    [SerializeField] private int _startingMoney;

    private void Awake()
    {
        Instance = this;
        Deposite(_startingMoney);
    }

    private void Start()
    {
  
    }


    public void Deposite(BigInteger value)
    {
        Money += value;
        OnBalanceChanged?.Invoke();
    }

    public void Withdraw(BigInteger value)
    {
        Money -= value;
        OnBalanceChanged?.Invoke();
    }

 
    public string GetCurrencyString()
    {
        BigInteger divisor;
        string suffix;

        if (Money >= new BigInteger(1000000000000000000))
        {
            divisor = new BigInteger(1000000000000000000);
            suffix = "ab";
        }
        else if (Money >= new BigInteger(1000000000000000))
        {
            divisor = new BigInteger(1000000000000000);
            suffix = "aa";
        }
        else if (Money >= new BigInteger(1000000000000))
        {
            divisor = new BigInteger(1000000000000);
            suffix = "T";
        }
        else if (Money >= 1000000000)
        {
            divisor = new BigInteger(1000000000);
            suffix = "B";
        }
        else if (Money >= 1000000)
        {
            divisor = new BigInteger(1000000);
            suffix = "M";
        }
        else if (Money >= 1000)
        {
            divisor = new BigInteger(1000);
            suffix = "K";
        }
        else
        {
            return Money.ToString();
        }

        BigInteger wholePart = Money / divisor;
        BigInteger fractionalPart = (Money % divisor) * 10 / divisor;
        string formattedString = $"{wholePart},{fractionalPart}";

        // If the fractional part is zero, remove it
        if (fractionalPart == 0)
        {
            formattedString = wholePart.ToString();
        }

        return formattedString + suffix;
    }
}