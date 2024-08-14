using UnityEngine;
using System.Collections.Generic;

public class CounterBehaviour : MonoBehaviour
{
    public List<PizzaBehaviour> ServingPizzas = new();
    [SerializeField] private Transform _seringPizzaOriginTransform;
    private Vector3 _servingPizzaOffset = new Vector3(0, 0.1f, 0f);
    public Transform GetPizzaTransform;
    public Vector3 TakePizzaPosition { get => GetPizzaTransform.position; }

    public bool IsServing = false;

    public void RefillPizza(PizzaBehaviour pizza)
    {
        if (pizza == null) return;
        ServingPizzas.Add(pizza);
        //pizza.transform.SetParent(_seringPizzaOriginTransform);
        //pizza.transform.position = GetServingPizzaPosition();

        Debug.Log("Refill pizza");
        pizza.transform.parent = null;
        pizza.MoveTo(GetServingPizzaPosition());
    }


    public PizzaBehaviour ServePizza()
    {
        var pizza = ServingPizzas[ServingPizzas.Count - 1];
        ServingPizzas.RemoveAt(ServingPizzas.Count - 1);

        return pizza;
    }


    private Vector3 GetServingPizzaPosition()
    {
        var position = _seringPizzaOriginTransform.position;
        //var position = Vector3.zero;
        for (int i = 0; i < ServingPizzas.Count; i++)
        {
            position += _servingPizzaOffset;
        }
        return position;
    }
}
