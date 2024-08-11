using CrashKonijn.Goap.Sensors;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;

public class IsHungrySensor : LocalWorldSensorBase
{
    public override void Created()
    {
     
    }

    public override SenseValue Sense(IMonoAgent agent, IComponentReference references)
    {
        var hungerBehaviour = references.GetCachedComponent<HungerBehaviour>();
        if (hungerBehaviour == null)
            return false;

        return hungerBehaviour.Hunger > 20f;
    }

    public override void Update()
    {
     
    }
}
