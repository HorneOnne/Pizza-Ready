using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using UnityEngine;

public class ClosestTableSensor : LocalTargetSensorBase
{
    private TableCollection _tableCollection;

    public override void Created()
    {
        this._tableCollection = GameObject.FindObjectOfType<TableCollection>();
    }

    public override ITarget Sense(IMonoAgent agent, IComponentReference references)
    {
        if (_tableCollection.Tables.Count == 0) return null;
        for (int i = 0; i < _tableCollection.Tables.Count ; i++)
        {
            if (_tableCollection.Tables[i].HasSeat(agent.GetComponent<AgentSeatBehaviour>()))
            {
                return new TransformTarget(_tableCollection.Tables[i].GetSeat(agent.GetComponent<AgentSeatBehaviour>()));                    
            }
        }

        return null;     
    }

    public override void Update()
    {

    }
}
