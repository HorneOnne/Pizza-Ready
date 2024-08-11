using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using UnityEngine;

public class ClosestPizzaSensor : LocalTargetSensorBase
{
    private PizzaBehaviour[] _pizzas;

    public override void Created()
    {
        this._pizzas = GameObject.FindObjectsOfType<PizzaBehaviour>();
    }

    public override ITarget Sense(IMonoAgent agent, IComponentReference references)
    {
       return new TransformTarget(_pizzas[0].transform);
    }

    public override void Update()
    {
       
    }
}

