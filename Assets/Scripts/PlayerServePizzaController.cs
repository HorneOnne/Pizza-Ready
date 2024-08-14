using UnityEngine;
using System.Collections.Generic;

public class  PlayerServePizzaController : MonoBehaviour
{
    public Stack<PizzaBehaviour> Pizzas = new();
    public Transform HoldPizzaTransform;
    private Vector3 _eachPizzaOffset = new Vector3(0, 0.1f, 0f);

    private int _maxPizzaHold = 2;

    public void TakeFromOven(PizzaBehaviour pizza)
    {
        Pizzas.Push(pizza);
        pizza.transform.SetParent(HoldPizzaTransform);
        pizza.MoveToLocal(GetPizzaPosition());
    }


    public PizzaBehaviour Drop()
    {
        if(Pizzas.Count == 0) return null;
        return Pizzas.Pop();
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

    public bool CanHoldMorePizza()
    {
        return Pizzas.Count < _maxPizzaHold;
    }
}
