using UnityEngine;

public class PizzaRefillCounter : MonoBehaviour
{
    [SerializeField] private CounterBehaviour _counter;

    private bool _hitPlayer = false;
    private float _refillPizzaTime = 0.25f;
    private float _refillPizzaTimer = 0.0f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _hitPlayer = true;
            _refillPizzaTimer = 0.0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_hitPlayer == false) return;

        _refillPizzaTimer += Time.deltaTime;
        if(_refillPizzaTimer > _refillPizzaTime)
        {
            _refillPizzaTimer -= _refillPizzaTime;
            if (other.CompareTag("Player"))
            {
                var playerServePizzaController = other.GetComponent<PlayerServePizzaController>();
                if (playerServePizzaController != null)
                {
                    _counter.RefillPizza(playerServePizzaController.Drop());
                }
            }
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _hitPlayer = false;
        }
    }
}