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
        var seat = references.GetCachedComponent<SeatBehaviour>();
        if (seat == null)
            return false;

        Debug.Log($"Has table sensor: {seat.Table != null}");
        return seat.Table != null;
    }

    public override void Update()
    {
       
    }
}
