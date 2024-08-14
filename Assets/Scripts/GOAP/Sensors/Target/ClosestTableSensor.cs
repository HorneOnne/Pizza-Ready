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
        if (_tables.Length == 0) return null;
        for (int i = 0; i < _tables.Length; i++)
        {
            if (_tables[i].HasSeat(agent.GetComponent<AgentSeatBehaviour>()))
            {
                return new TransformTarget(_tables[i].GetSeat(agent.GetComponent<AgentSeatBehaviour>()));                    
            }
        }

        return null;     
    }

    public override void Update()
    {

    }
}
