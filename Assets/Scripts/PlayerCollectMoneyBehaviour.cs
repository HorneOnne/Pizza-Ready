using UnityEngine;

public class PlayerCollectMoneyBehaviour : MonoBehaviour
{
    [SerializeField] private LayerMask _moneyLayer;
    public Transform CollectMoneyTransform;
    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & _moneyLayer) != 0)
        {
            Debug.Log("Money collected!");
            if(other.TryGetComponent<MoneyCollector>(out var moneyCollector))
            {
                moneyCollector.CollectedBy(this);

            }          
        }
    }
}
