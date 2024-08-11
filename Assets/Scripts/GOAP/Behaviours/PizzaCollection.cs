using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;


public class PizzaCollection : MonoBehaviour
{
    private readonly List<PizzaBehaviour> _pizzas = new();

    public void Add(PizzaBehaviour pizza)
    {
        _pizzas.Add(pizza);
    }

    public void Remove(PizzaBehaviour pizza)
    {
        _pizzas.Remove(pizza);
    }

    public PizzaBehaviour[] Get()
    {
        return _pizzas.ToArray();
    }

    public bool Any()
    {
        return this._pizzas.Any();  
    }
}
