using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;

public class TransformSensor : LocalTargetSensorBase
{
    public override void Created()
    {
    
    }

    public override ITarget Sense(IMonoAgent agent, IComponentReference references)
    {
        return new TransformTarget(agent.transform);
    }

    public override void Update()
    {
       
    }
}
