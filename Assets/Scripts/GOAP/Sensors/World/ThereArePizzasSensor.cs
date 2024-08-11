using CrashKonijn.Goap.Sensors;
using CrashKonijn.Goap.Classes;
using UnityEngine;

public class ThereArePizzasSensor : GlobalWorldSensorBase
{
    private PizzaCollection _pizzaCollection;
    public override void Created()
    {
       _pizzaCollection = GameObject.FindObjectOfType<PizzaCollection>();
    }

    public override SenseValue Sense()
    {
        return _pizzaCollection.Any();
    }
}
