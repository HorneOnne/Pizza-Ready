using CrashKonijn.Goap.Sensors;
using CrashKonijn.Goap.Classes;
using UnityEngine;

public class HasTableSensor : GlobalWorldSensorBase
{
    private TableBehaviour[] _tableBehaviours;

    public override void Created()
    {
        _tableBehaviours = GameObject.FindObjectsOfType<TableBehaviour>();
    }

    public override SenseValue Sense()
    {
        if(_tableBehaviours.Length > 0 )
        {
            Debug.Log("Has table");
        }
        else
        {
            Debug.Log("Doesn't has table");
        }

        return _tableBehaviours.Length > 0;
    }
}
