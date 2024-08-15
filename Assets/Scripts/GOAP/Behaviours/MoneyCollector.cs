using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using DG.Tweening;

public class MoneyCollector : MonoBehaviour
{
    [SerializeField] private Money _moneyPrefab;
    public List<Money> Moneys = new();
    public bool IsCollecting { get; private set; } = false;
    private int _currentHeight = 0;



    private void Awake()
    {
        //AddMoney(5, 5, 3);
    }

    private void OnEnable()
    {
        EatPizzaAction.OnAgentEatCompleted += OnAgentPayment;
    }

    private void OnDisable()
    {
        EatPizzaAction.OnAgentEatCompleted -= OnAgentPayment;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            AddMoney(5, 1, 3);
        }
    }

    public void AddMoney(int width, int height, int depth)
    {
        if (IsCollecting) return;
        int startY = _currentHeight;
        int endY = _currentHeight + height;
        _currentHeight += height;
        for (int z = 0; z < depth; z++)
        {
            for (int y = startY; y < endY; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var moneyInstance = Instantiate(_moneyPrefab, transform.position + new Vector3(_moneyPrefab.Size.x * x, _moneyPrefab.Size.y * y, _moneyPrefab.Size.z * z), Quaternion.identity);
                    Moneys.Add(moneyInstance);
                }
            }
        }
    }


    public void CollectedBy(PlayerCollectMoneyBehaviour player)
    {
        if (IsCollecting) return;
        IsCollecting = true;
        StartCoroutine(CollectedByCoroutine(player));
    }

    private IEnumerator CollectedByCoroutine(PlayerCollectMoneyBehaviour player)
    {
        for (int i = 0; i < Moneys.Count; i++)
        {
            //Moneys[i].transform.DOScale(0f, 0.1f);
            Moneys[i].MoveTo(player.CollectMoneyTransform, () =>
            {
                //Moneys[i].Hide();
                CurrencyManager.Instance.Deposite(10);
                AudioManager.Instance.PlaySfx(transform.position);
            });    
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < Moneys.Count; i++)
        {
            Destroy(Moneys[i].gameObject);
        }
        Moneys.Clear();
        _currentHeight = 0;
        IsCollecting = false;
    }

    public void OnAgentPayment()
    {
        AddMoney(5, 1, 3);
    }

}
