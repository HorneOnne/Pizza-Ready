using System.Collections;
using System.Collections.Generic;
using CrashKonijn.Goap.Sensors;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
public class HasPizzaSensor : LocalWorldSensorBase
{
    public override void Created()
    {
   
    }

    public override SenseValue Sense(IMonoAgent agent, IComponentReference references)
    {
        var inventory = references.GetCachedComponent<InventoryBehaviour>();
        if (inventory == null)
            return false;

        return inventory.Pizza != null;
    }

    public override void Update()
    {
        
    }
}
