using UnityEngine;

public class PizzaRefillCounter : MonoBehaviour
{
    [SerializeField] private CounterBehaviour _counter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var playerServePizzaController = other.GetComponent<PlayerServePizzaController>();  
            if(playerServePizzaController != null )
            {
                Debug.Log("Refill");
                _counter.RefillPizza(playerServePizzaController.Drop());
            }         
        }
    }
}