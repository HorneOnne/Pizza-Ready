using UnityEngine;
using System.Collections.Generic;

public class  PlayerServePizzaController : MonoBehaviour
{
    public List<PizzaBehaviour> Pizzas = new();
    public Transform HoldPizzaTransform;
    private Vector3 _eachPizzaOffset = new Vector3(0, 0.1f, 0f);

    public void Get(PizzaBehaviour pizza)
    {
        Pizzas.Add(pizza);
        pizza.transform.SetParent(HoldPizzaTransform);
        pizza.transform.localPosition = GetPizzaPosition();
    }

    private Vector3 GetPizzaPosition()
    {
        var position = Vector3.zero;
        for (int i = 0; i < Pizzas.Count; i++)
        {
            position += _eachPizzaOffset;
        }
        return position;
    }
}
