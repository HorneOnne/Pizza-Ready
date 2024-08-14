using UnityEngine;

public class InventoryBehaviour : MonoBehaviour
{
    public PizzaBehaviour Pizza;

    private void Awake()
    {
    
    }


    public void Put(PizzaBehaviour pizza)
    {
        Pizza = pizza;
        Pizza.PickUp();

        pizza.transform.SetParent(this.transform);
        pizza.transform.position = this.GetComponent<AgentController>().HandHoldTransform.position;
    }

    public PizzaBehaviour Get()
    {
        if (Pizza == null) return null;
        Pizza.Drop();
        return Pizza;
    }
}
