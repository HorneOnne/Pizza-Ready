using CrashKonijn.Goap.Sensors;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;

public class IsWaitToTakePizzaSensor : LocalWorldSensorBase
{
    public override void Created()
    {
        
    }

    public override SenseValue Sense(IMonoAgent agent, IComponentReference references)
    {
        var queueBehaviour = agent.GetComponent<AgentQueuingBehaviour>();
        if (queueBehaviour == null)
            return false;

        return queueBehaviour.QueueIndex == 0;
    }

    public override void Update()
    {
       
    }
}