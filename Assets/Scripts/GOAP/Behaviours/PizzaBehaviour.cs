using UnityEngine;
using CrashKonijn.Goap.Enums;

public class PizzaBehaviour : MonoBehaviour
{
    public bool IsPickUp { get; private set; }
    private PizzaCollection _pizzaCollection;

    private void Awake()
    {
        _pizzaCollection = FindAnyObjectByType<PizzaCollection>();
    }

    private void OnEnable()
    {
        _pizzaCollection.Add(this);
    }

    private void OnDisable()
    {
        _pizzaCollection.Remove(this);
    }

    public void PickUp()
    {
        this.IsPickUp = true;
    }

    public void Drop()
    {
        this.IsPickUp = false;
    }
}
