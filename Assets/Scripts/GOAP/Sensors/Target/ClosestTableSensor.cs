using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using UnityEngine;

public class ClosestTableSensor : LocalTargetSensorBase
{
    private TableBehaviour[] _tables;

    public override void Created()
    {
        this._tables = GameObject.FindObjectsOfType<TableBehaviour>();
    }

    public override ITarget Sense(IMonoAgent agent, IComponentReference references)
    {
        //Debug.Log("Sense closest table.");
        //return new PositionTarget(new Vector3(30, 0, 0));
        return new TransformTarget(_tables[0].transform);
    }

    public override void Update()
    {

    }
}

