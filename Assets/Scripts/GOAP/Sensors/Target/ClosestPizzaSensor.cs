using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using UnityEngine;
using System.Linq;
public class ClosestPizzaSensor : LocalTargetSensorBase
{
    //private PizzaCollection _pizzaCollection;

    //public override void Created()
    //{
    //    this._pizzaCollection = GameObject.FindObjectOfType<PizzaCollection>();
    //}

    //public override ITarget Sense(IMonoAgent agent, IComponentReference references)
    //{ 
    //    if(_pizzaCollection.Get().Length > 0)
    //    {
    //        return new TransformTarget(_pizzaCollection.Get()[0].transform);
    //    }

    //    return null;
    //}

    //public override void Update()
    //{

    //}

    private CounterBehaviour _counterBehaviour;

    public override void Created()
    {
        this._counterBehaviour = GameObject.FindObjectOfType<CounterBehaviour>();
    }

    public override ITarget Sense(IMonoAgent agent, IComponentReference references)
    {
        if(_counterBehaviour == null)
        {
            this._counterBehaviour = GameObject.FindObjectOfType<CounterBehaviour>();
            return null;
        }
        if(_counterBehaviour.ServingPizzas.Count > 0 && _counterBehaviour.IsServing)
        {
            //return new TransformTarget(_counterBehaviour.ServePizza().transform);
            return new TransformTarget(_counterBehaviour.GetPizzaTransform);
        }   
        return null;
    }

    public override void Update()
    {

    }
}
