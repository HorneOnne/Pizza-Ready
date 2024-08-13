using CrashKonijn.Goap.Sensors;
using CrashKonijn.Goap.Classes;
using UnityEngine;
using CrashKonijn.Goap.Interfaces;

public class HasTableSensor : LocalWorldSensorBase
{
    public override void Created()
    {
       
    }

    public override SenseValue Sense(IMonoAgent agent, IComponentReference references)
    {
        Debug.Log("has table sensor");
        var seat = references.GetCachedComponent<AgentSeatBehaviour>();
        if (seat == null)
            return false;

        Debug.Log($"HasTableSensor: {seat.Table != null}");
        return seat.Table != null;
    }

    public override void Update()
    {
       
    }
}

