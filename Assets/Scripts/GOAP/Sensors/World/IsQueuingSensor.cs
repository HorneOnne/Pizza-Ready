using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;

public class IsQueuingSensor : LocalWorldSensorBase
{
    public override void Created()
    {
      
    }

    public override SenseValue Sense(IMonoAgent agent, IComponentReference references)
    {
        var queueBehaviour = references.GetCachedComponent<AgentQueuingBehaviour>();
        if (queueBehaviour == null)
            return false;

        return queueBehaviour.IsWaitingInQueue;
      
    }

    public override void Update()
    {
        
    }
}