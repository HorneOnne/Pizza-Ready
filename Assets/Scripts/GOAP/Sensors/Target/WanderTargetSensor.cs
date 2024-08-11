using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using UnityEngine;

public class WanderTargetSensor : LocalTargetSensorBase
{
    public override void Created()
    {
      
    }

    public override ITarget Sense(IMonoAgent agent, IComponentReference references)
    {
        var randomPosition = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
        return new PositionTarget(randomPosition);
    }

    public override void Update()
    {
        
    }
}