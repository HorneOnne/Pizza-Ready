using UnityEngine;

public class InventoryBehaviour : MonoBehaviour
{
    public PizzaBehaviour Pizza;
    private PizzaCollection _pizzaCollection;
    private void Awake()
    {
        _pizzaCollection = FindAnyObjectByType<PizzaCollection>();
    }


    public void Put(PizzaBehaviour pizza)
    {
        Pizza = pizza;
        Pizza.PickUp();

        pizza.transform.SetParent(this.transform);
        pizza.transform.position = this.GetComponent<AgentController>().HandHoldTransform.position;

        _pizzaCollection.Remove(pizza);
    }

    public PizzaBehaviour Get()
    {
        if (Pizza == null) return null;
        Pizza.Drop();
        return Pizza;
    }
}
