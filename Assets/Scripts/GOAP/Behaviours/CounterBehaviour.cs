using UnityEngine;
using System.Collections.Generic;

public class CounterBehaviour : MonoBehaviour
{
    public List<PizzaBehaviour> ServingPizzas = new();
    [SerializeField] private Transform _seringPizzaOriginTransform;
    private Vector3 _servingPizzaOffset = new Vector3(0, 0.1f, 0f);
    public Transform GetPizzaTransform;

    public Vector3 TakePizzaPosition { get => GetPizzaTransform.position; }


    public void AddPizza(PizzaBehaviour pizza)
    {
        ServingPizzas.Add(pizza);
        pizza.transform.position = GetServingPizzaPosition();
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
        for (int i = 0; i < ServingPizzas.Count; i++)
        {
            position += _servingPizzaOffset;
        }
        return position;
    }
}
