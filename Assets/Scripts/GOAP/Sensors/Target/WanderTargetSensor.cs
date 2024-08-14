using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using UnityEngine;

public class WanderTargetSensor : LocalTargetSensorBase
{
    private AgentsController _agentsController;
    public override void Created()
    {
        _agentsController = GameObject.FindObjectOfType<AgentsController>();    
    }

    public override ITarget Sense(IMonoAgent agent, IComponentReference references)
    {
        //var randomPosition = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
        //return new PositionTarget(randomPosition);

        return new PositionTarget(_agentsController.Points[Random.Range(0, _agentsController.Points.Length)].position);
    }

    public override void Update()
    {
        
    }
}