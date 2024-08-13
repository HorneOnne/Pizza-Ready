using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using UnityEngine;

public class ClosestQueueSensor : LocalTargetSensorBase
{
    private WaitingLane _waitingLane;

    public override void Created()
    {
      this._waitingLane = GameObject.FindObjectOfType<WaitingLane>();
    }

    public override ITarget Sense(IMonoAgent agent, IComponentReference references)
    {
        Debug.Log("ClosestQueueSensor");
        return new TransformTarget(_waitingLane.transform);
        //return new PositionTarget(_waitingLane.GetQueuePosition(agent));
        //return new TransformTarget(_waitingLane.GetQueuePosition(agent.GetComponent<AgentQueuingBehaviour>()));
    }

    public override void Update()
    {
     
    }
}
